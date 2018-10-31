using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dystopia_sharp.Types;

namespace dystopia_sharp.Types
{
    public delegate void DoFun(CharData ch, string argument);
    public delegate bool SpecFun(CharData ch);
    public delegate void SpellFun(int sn, int level, CharData ch, object vo);
}
