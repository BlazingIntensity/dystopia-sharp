using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    [Flags]
    public enum ExitFlags : int
    {
        None = 0,
        IsDoor = 1 << 0,
        Closed = 1 << 1,
        Locked = 1 << 2,
        PickProof = 1 << 5,
        NoPass = 1 << 6,
        Easy = 1 << 7,
        Hard = 1 << 8,
        Infuriating = 1 << 9,
        NoClose = 1 << 10,
        NoLock = 1 << 11,
        IceWall = 1 << 12,
        FireWall = 1 << 13,
        SwordWall = 1 << 14,
        PrismaticWall = 1 << 15,
        IronWall = 1 << 16,
        MushroomWall = 1 << 17,
        CaltropWall = 1 << 18,
        AshWall = 1 << 19,
        Warding = 1 << 20
    }

    public class ExitData
    {
        // public ExitData Prev { get; set; }
        // public ExitData Next { get; set; }
        // public ExitData RExit { get; set; }

        public RoomDef ToRoom { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public Vnum Vnum { get; set; }
        public Vnum RVnum { get; set; }
        public int ExitInfo { get; set; }
        public Vnum Key { get; set; }
        public short VDir { get; set; }
        public ExitFlags RSFlags { get; set; }
        public int OrigDoor { get; set; }

        public bool IsDoor
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
