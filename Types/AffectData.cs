using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class AffectData
    {
        // public AffectData Next { get; set; }
        public short Type { get; set; }
        public short Duration { get; set; }
        public short Location { get; set; }
        public short Modifier { get; set; }
        public int BitVector { get; set; }
    }
}
