using dystopia_sharp.Commands;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp
{
    public class Server
    {
        static Logger log = Logger.Create("ServerLogger");
        public int Port { get; private set; }
        public bool Copyover { get; private set; }

        Socket control;
        bool running;

        List<UserConnection> connections = new List<UserConnection>();

        public Server(int port = 8888, bool copyover = false)
        {
            Port = port;
            Copyover = copyover;
            CmdType.RegisterProvider(new PlaceholderProvider());
        }

        void CrashRecovery()
        {
            // TODO
            // signal(SIGSEGV, crashrecov);
        }

        void HandleCopyover()
        {
            if (!Copyover)
            {
                control = new Socket(SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                // command line
                //control = new Socket(socketinfo);
            }
            control.Bind(new IPEndPoint(IPAddress.Any, Port));
            control.Listen(10);
        }

        public void Run()
        {
            Logger.Init();
            var now = DateTime.UtcNow;

            HandleCopyover();
 	        Content.Initialize(now, Copyover);

            Arena.State = ArenaState.Open;
            log.Info($"Dystopia is ready to rock on port {Port}.");

            running = true;
            GameLoop(control);

            control.Dispose();

            log.Info("Normal termination of game.");
        }

        void GameLoop(Socket control)
        {
            var removeMe = new List<UserConnection>();
            while (running)
            {
                removeMe.Clear();
                if (control.Poll(0, SelectMode.SelectRead))
                {
                    var newSock = control.Accept();
                    connections.Add(new UserConnection(newSock, this));
#if TEMP_EXCEPTIONS
                    throw new NotImplementedException();
#endif
                }

                foreach (var conn in connections)
                {
                    if (!conn.Update()) removeMe.Add(conn);
                }

                foreach (var conn in removeMe)
                {
                    connections.Remove(conn);
                }

                UpdateHandler();

                removeMe.Clear();
                foreach (var conn in connections)
                {
                    if (!conn.ProcessOutput()) removeMe.Add(conn);
                }

                foreach (var conn in removeMe)
                {
                    connections.Remove(conn);
                }

                SyncToClock();
            }
        }

        void UpdateHandler()
        {
#if TEMP_EXCEPTIONS
            throw new NotImplementedException("Implement update_handler");
#endif
        }

        void SyncToClock()
        {
#if TEMP_EXCEPTIONS
            throw new NotImplementedException("Implement SyncToClock");
#endif
            /*
 * Synchronize to a clock.
 * Sleep( last_time + 1/PULSE_PER_SECOND - now ).
 * Careful here of signed versus unsigned arithmetic.
 */
        }

        public void Chat(string message)
        {
            var bytes = Encoding.ASCII.GetBytes($"[CHAT] {message}\n\r");
            foreach (var conn in connections)
            {
                conn.SendToCharacter(bytes);
            }
        }
    }
}
