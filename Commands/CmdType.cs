using dystopia_sharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Commands
{
    public class CmdType
    {
        public string Name { get; set; }
        public DoFun DoFun { get; set; }
        public short Position { get; set; }
        public short Level { get; set; }
        public short Log { get; set; }
        public int Race { get; set; }
        public short Discipline { get; set; }
        public short DiscLevel { get; set; }

        static readonly List<CmdType> cmdTable = new List<CmdType>();

        public static readonly DoFun dummy = (ch, arg) => { };

        public CmdType(string name, DoFun doFun, short position, short level, short log, int race, short dicipline, short discLevel)
        {
            Name = name;
            DoFun = doFun;
            Position = position;
            Level = level;
            Log = log;
            Race = race;
            Discipline = Discipline;
            DiscLevel = discLevel;
        }

        public static void RegisterProvider(ICommandProvider prov)
        {
            lock(cmdTable)
            {
                cmdTable.AddRange(prov.GetCommands());
            }
        }

        public static bool TryLookup(string name, out CmdType retVal)
        {
            lock (cmdTable)
            {
                retVal = cmdTable.Find(md => md.Name == name);
                return retVal != null;
            }
        }

    }
}
