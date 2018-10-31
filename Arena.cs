using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp
{
    public enum ArenaState : byte
    {
        Open = 0,
        Start,
        Busy,
        Lock
    }

    public class Arena
    {
        public static ArenaState State { get; set; }
    }
}
