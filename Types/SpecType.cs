using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dystopia_sharp.Types;

namespace dystopia_sharp.Types
{
    public class SpecType
    {
        public string SpecName { get; set; }
        public SpecFun SpecFun { get; set; }

        static readonly Dictionary<string, SpecType> specTypes = new Dictionary<string, SpecType>();

        public static bool TryLookup(string name, out SpecType retVal)
        {
            Content.log.Warn("No spectypes defined.");
            retVal = new SpecType
            {
                SpecName = name,
                SpecFun = cd => true
            };

            return true;
            // TODO ???????????????
#if false
            return specTypes.TryGetValue(name, out retVal);
#endif
        }

        public static void LoadFromArea(StringReader sr)
        {
            while (true)
            {
                var letter = sr.ReadLetter();
                switch (letter)
                {
                    case 'S':
                        return;

                    case '*':
                        sr.ReadToEOL();
                        break;

                    case 'M':
                        MobileDef md;
                        if (MobileDef.TryGetMobileDef(sr.ReadVnum(), out md))
                        {
                            SpecType st;
                            if (!TryLookup(sr.ReadWord(), out st))
                            {
                                throw new Exception($"Load_specials: 'M': vnum {md.Vnum}.");
                            }
                            md.SpecFun = st.SpecFun;
                        }
                        sr.ReadToEOL();
                        break;

                    default:
                        throw new Exception($"Load_specials: letter '{letter}' not *MS.");
                }
            }
        }
    }
}