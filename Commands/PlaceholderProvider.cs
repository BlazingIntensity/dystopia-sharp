using dystopia_sharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Commands
{
    public class PlaceholderProvider : ICommandProvider
    {
        static readonly CmdType[] commands = new[]
        {
            new CmdType("chat", Chat, 0, 0, 0, 0, 0, 0),
            new CmdType("quit", Quit, 0, 0, 0, 0, 0, 0),
        };

        public IEnumerable<CmdType> GetCommands()
        {
            return commands;
        }

        static void Quit(CharData ch, string argument)
        {
            ch.Connection.Disconnect();
        }

        static void Chat(CharData ch, string argument)
        {
            ch.Connection.Chat(argument);
        }
    }
}
