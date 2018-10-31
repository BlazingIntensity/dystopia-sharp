using dystopia_sharp.Commands;
using dystopia_sharp.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp
{
    enum ConnState
    {
        UserName = 0,
        Pass,
        Interp
    }
    public class UserConnection
    {
        static readonly Logger log = Logger.Create<UserConnection>();
        public Socket Socket { get; private set; }
        public Server Server { get; private set; }
        public CharData Character { get; private set; }
        ConnState state;

        readonly Queue<byte> byteQueue = new Queue<byte>();
        int cmdCount = 0;

        public bool IsConnected {  get { return Socket != null && Socket.Connected; } }

        public UserConnection(Socket socket, Server server)
        {
            Server = server;
            Socket = socket;
            socket.NoDelay = true;
            Socket.Send(new byte[] { 255, 251, 1, 0 });
        }

        public void SaveCharacter()
        {
#if TEMP_EXCEPTIONS
            throw new NotImplementedException("Implement save_char_obj");
#endif
        }

        public void Disconnect()
        {
            try
            {
                SaveCharacter();
                Socket.Disconnect(true);
                Socket.Close();
                Socket.Dispose();
                Socket = null;
            }
            catch (Exception e)
            {
                log.Error("Unhandled exception in Disconnect: " + e.Message);
            }
        }

        public bool HandleInput()
        {
            //throw new NotImplementedException("Implement wait, stop_idling, read_from_buffer, nanny, and interpret");
            if (!Socket.Connected) return false;

            byte[] buffer = new byte[1024];
            int numRead = Socket.Receive(buffer);

            if (numRead == 0) return false;


            for (int i = 0; i < numRead; ++i)
            {
                var curByte = buffer[i];
                byteQueue.Enqueue(curByte);
                if (curByte == '\n' || curByte == 255)
                {
                    ++cmdCount;
                }
            }

            var curCmd = 0;
            var numCmd = cmdCount;
            for (; curCmd < numCmd && IsConnected; ++curCmd)
            {

                for (int i = 0; i < buffer.Length && IsConnected; ++i)
                {
                    buffer[i] = byteQueue.Dequeue();
                    bool done = false;
                    switch (buffer[i])
                    {
                        case (byte)'\n':
                            var line = Encoding.ASCII.GetString(buffer, 0, i + 1).Trim();
                            done = ProcessLine(line);
                            break;
                        case 255:
                            done = ProcessIAC();
                            break;
                    }
                    if (done) break;
                }
            }
            cmdCount -= numCmd;
            return IsConnected;
        }

        bool ProcessIAC()
        {
            byteQueue.Dequeue();
            byteQueue.Dequeue();
            return true;
        }

        bool ProcessLine(string line)
        {
            switch(state)
            {
                case ConnState.UserName:
                    Character = CharData.Load(line, this);
                    state = ConnState.Pass;
                    break;
                case ConnState.Pass:
                    if (!Character.Authenticate(line))
                    {
                        SendToCharacter("Invaild password.");
                        Disconnect();
                        break;
                    }
                    state = ConnState.Interp;
                    break;
                case ConnState.Interp:
                    Interp(line);
                    break;
            }
            
            return true;
        }

        void Interp(string line)
        {
            var space = line.IndexOf(' ');
            string cmd, arg;
            if (space > 0)
            {
                cmd = line.Substring(0, space);
                arg = line.Substring(space + 1);
            }
            else
            {
                cmd = line;
                arg = string.Empty;
            }
            CmdType exec;
            if (CmdType.TryLookup(cmd, out exec))
            {
                exec.DoFun(Character, arg);
            }
            else
            {
                SendToCharacter($"Huh? Command '{cmd}' not found.\n\r");
            }
        }

        public void SendToCharacter(string text)
        {
            SendToCharacter(Encoding.ASCII.GetBytes(text));
        }

        public void SendToCharacter(byte[] bytes)
        {
            SendToCharacter(bytes, 0, bytes.Length);
        }

        public void SendToCharacter(byte[] bytes, int offset, int numBytes)
        {
            Socket.Send(bytes, offset, numBytes, SocketFlags.None);
        }

        public bool ProcessOutput()
        {
#if TEMP_EXCEPTIONS
            throw new NotImplementedException("Implement process_output");
#else
            return true;
#endif
        }

        public bool Update()
        {
            if (Socket == null) return false;
            if (Socket.Poll(0, SelectMode.SelectError))
            {
                Disconnect();
                return false;
            }

            if (Socket.Poll(0, SelectMode.SelectRead))
            {
                var hi = HandleInput();
                if (!hi) Disconnect();
                return hi;
            }
            return true;
        }

        public void Chat(string message)
        {
            Server.Chat(message);
        }
    }
}
