using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dystopia_sharp;
using dystopia_sharp.Types;

namespace dystopia_sharp.Types
{
    public enum Gender : byte
    {
        Neutral = 0,
        Male = 1,
        Female = 2
    }

    [Flags]
    public enum MobActs
    {
        None = 0,
        IsNpc = 1 << 0,
        Sentinel = 1 << 1,
        Scavenger = 1 << 2,
        Aggressive = 1 << 3,
        StayArea = 1 << 4,
        Wimpy = 1 << 5,
        Pet = 1 << 6,
        Train = 1 << 7,
        Practice = 1 << 8,
        Mount = 1 << 9,
        NoParts = 1 << 10,
        NoExp = 1 << 11,
        Prototype = 1 << 12,
        NoAutoKill = 1 << 13,
        NoExp2 = 1 << 14,
    }

    public class MobileDef
    {
        public SpecFun SpecFun { get; set; }
        public List<ShopData> Shops { get; set; }
        //CHAR_DATA* mount;
        //CHAR_DATA* wizard;
        public AreaData Area { get; set; }
        public string Hunting { get; set; }
        public string PlayerName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Description { get; set; }
        public string Lord { get; set; }
        public string Morph { get; set; }
        public string CreateTime { get; set; }
        public string PLoad { get; set; }
        public string LastTime { get; set; }
        public string LastHost { get; set; }
        public string PowerType { get; set; }
        public string PowerAction { get; set; }
        public string Prompt { get; set; }
        public string CPrompt { get; set; }
        public short SpecType { get; set; }
        public short SpecPower { get; set; }
        public int[] LocationHP { get; set; }
        public Vnum Vnum { get; set; }
        public short Count { get; set; }
        public short Killed { get; set; }
        public Gender Sex { get; set; }
        public short Mounted { get; set; }
        public short Home { get; set; }
        public int Level { get; set; }
        public int Immune { get; set; }
        public int PolyAff { get; set; }
        public int VampAff { get; set; }
        public int ItemAffect { get; set; }
        public int Form { get; set; }
        public MobActs Act { get; set; }
        public int Extra { get; set; }
        public int AffectedBy { get; set; }
        public int AffectedBy2 { get; set; }
        public int Alignment { get; set; }
        public int HitRoll { get; set; } // Unused
        public int AC { get; set; } // Unused
        public int HitNoDice { get; set; } // Unused
        public int HitSizeDice { get; set; } // Unused
        public int HitPlus { get; set; } // Unused
        public int DamNoDice { get; set; } // Unused
        public int DamSizeDice { get; set; } // Unused
        public int DamPlus { get; set; } // Unused
        public int Gold { get; set; } // Unused
        // public int Special { get; set; }
        // public int Class { get; set; }


        static readonly List<MobileDef> mobiles = new List<MobileDef>();

        MobileDef()
        {
            Shops = new List<ShopData>();
            LocationHP = new int[7];
        }

        public static bool TryGetMobileDef(Vnum vnum, out MobileDef retVal)
        {
            lock (mobiles)
            {
                retVal = mobiles.Find(md => md.Vnum == vnum);
                return retVal != null;
            }
        }

        public static void LoadFromArea(StringReader sr, AreaData area)
        {
            while (true)
            {
                if (area == null)
                {
                    throw new Exception("Load_mobiles: no #AREA seen yet.");
                }

                var letter = sr.ReadLetter();

                if (letter != '#')
                {
                    throw new Exception("# not found");
                }

                var vnum = sr.ReadVnum();
                if (vnum == Vnum.None) break;

                MobileDef existing;
                if (TryGetMobileDef(vnum, out existing))
                {
                    throw new Exception($"Load_mobiles: vnum {vnum} duplicated.");
                }

                var md = new MobileDef();
                md.Vnum = vnum;
                md.Area = area;
                md.PlayerName = sr.ReadString();
                md.ShortDescription = sr.ReadString();
                // TODO ToUpper first char
                md.LongDescription = sr.ReadString();
                // TODO ToUpper first char
                md.Description = sr.ReadString();
                md.Act = ((MobActs)sr.ReadNumber()) | MobActs.IsNpc;
                md.AffectedBy = sr.ReadNumber();
                md.Alignment = sr.ReadNumber();
                letter = sr.ReadLetter();
                md.Level = Content.Random.Fuzzy(sr.ReadNumber());

                // Old unused stuff for imps who want to use the old-style stats-in-files method.
                md.HitRoll = sr.ReadNumber();
                md.AC = sr.ReadNumber();
                md.HitNoDice = sr.ReadNumber();

                sr.ReadLetter(); // d
                md.HitSizeDice = sr.ReadNumber();

                sr.ReadLetter(); // + 
                md.HitPlus = sr.ReadNumber();
                md.DamNoDice = sr.ReadNumber();

                sr.ReadLetter(); // d
                md.DamSizeDice = sr.ReadNumber();

                sr.ReadLetter(); // +
                md.DamPlus = sr.ReadNumber();
                md.Gold = sr.ReadNumber();

                sr.ReadNumber(); // xp
                sr.ReadNumber(); // position
                sr.ReadNumber(); // startpos

                // Done with unused shit
                md.Sex = (Gender)sr.ReadNumber();
                if (letter != 'S')
                {
                    throw new Exception($"Load_mobiles: vnum {vnum} non-S.");
                }


                // TODO ??????

                lock (mobiles)
                {
                    mobiles.Add(md);
                }
                //iHash = vnum % MAX_KEY_HASH;
                //pMobIndex->next = mob_index_hash[iHash];
                //mob_index_hash[iHash] = pMobIndex;
                //top_mob_index++;
                //top_vnum_mob = top_vnum_mob < vnum ? vnum : top_vnum_mob;  /* OLC */
                //assign_area_vnum(vnum);                                  /* OLC */

                //kill_table[URANGE(0, pMobIndex->level, MAX_LEVEL - 1)].number++;
            }
        }
    }
}
