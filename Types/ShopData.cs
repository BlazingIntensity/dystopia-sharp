using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class ShopData
    {
        //public ShopData Next { get; set; }
        public Vnum Keeper { get; set; }
        public short[] BuyType { get; set; }
        public short ProfitBuy { get; set; }
        public short ProfitSell { get; set; }
        public Range<short> Hours { get; set; }

        public const int MAX_TRADE = 5;

        public ShopData()
        {
            BuyType = new short[MAX_TRADE];
        }

        public static void LoadFromArea(StringReader sr)
        {
            while (true)
            {
                var vnum = sr.ReadVnum();
                if (vnum == Vnum.None) break;

                var sd = new ShopData { Keeper = vnum };
                for (int i = 0; i < MAX_TRADE; ++i)
                {
                    sd.BuyType[i] = sr.ReadShort();
                }

                sd.ProfitBuy = sr.ReadShort();
                sd.ProfitSell = sr.ReadShort();
                var open = sr.ReadShort();
                var close = sr.ReadShort();
                sd.Hours = new Range<short>(open, close);
                sr.ReadToEOL();

                MobileDef md;
                if (MobileDef.TryGetMobileDef(sd.Keeper, out md))
                {
                    md.Shops.Add(sd);
                }
                else
                {
                    throw new Exception($"Keeper {sd.Keeper} not found for shop.");
                }
            }
        }
    }
}
