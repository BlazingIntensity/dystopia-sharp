using CryptSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class CharData
    {

        public UserConnection Connection { get; private set; }
        public CharData Next { get; set; }
        public CharData PrevInRoom { get; set; }
        public CharData NextInRoom { get; set; }
        public CharData Master { get; set; }
        public CharData Leader { get; set; }
        public CharData Fighting { get; set; }
        public CharData Embracing { get; set; }
        public CharData Embraced { get; set; }
        public CharData BlinkyKill { get; set; }
        public CharData Reply { get; set; }
        public CharData Mount { get; set; }
        public CharData Wizard { get; set; }
        public CharData Challenger { get; set; }
        public CharData Challenged { get; set; }
        public CharData Gladiator { get; set; }
        public SpecFun SpecFun { get; set; }
        public MobileDef IndexData { get; set; }
        // public DescriptorData desc { get; set; } // UserConn
        public List<AffectData> Affected { get; set; }
        public List<ObjectData> Carrying { get; set; }
        public RoomDef InRoom { get; set; }
        public RoomDef WasInRoom { get; set; }
        public dynamic PCData { get; set; }
        public DoFun LastCmd { get; set; }
        public DoFun PrevCmd { get; set; }
        public string Hunting { get; set; }
        public string Name { get; set; }
        public string PLoad { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Description { get; set; }
        public string Lord { get; set; }
        public string Morph { get; set; }
        public string CreateTime { get; set; }
        public string LastTime { get; set; }
        public string LastHost { get; set; }
        public string PowerAction { get; set; }
        public string PowerType { get; set; }
        public string Prompt { get; set; }
        public string CPrompt { get; set; }
        public string Prefix { get; set; }
        public Gender Sex { get; set; }
        public int Class_ { get; set; }
        public int Immune { get; set; }
        public int PolyAff { get; set; }
        public int VampAffA { get; set; }
        public int FightTimer { get; set; }
        public int ItemAffect { get; set; }
        public int Form { get; set; }
        public int Warp { get; set; }
        public int ExpLevel { get; set; }
        public int ExpGained { get; set; }
        public int[] Power { get; set; }
        public int XHitRoll { get; set; }
        public int XDamRoll { get; set; }
        // SMAUUUUUUUUUUUUUUUUG
        public object DestBuf { get; set; }
        public object SparePtr { get; set; }
        public int TempNum { get; set; }
        // public EditorData Editor { get; set; }
        public short SubState { get; set; }
        public int PageLen { get; set; }
        public short InterPage { get; set; }
        public short InterType { get; set; }
        public char InterEditing { get; set; }
        public int InterEditingVnum { get; set; }
        public short InterSubstate { get; set; }
        // Dh
        public int CCland { get; set; }
        public int Flag2 { get; set; }
        public int Flag3 { get; set; }
        public int Flag4 { get; set; }
        public short Generation { get; set; }
        public short Primary { get; set; }
        public short ProperSize { get; set; }
        public short Size { get; set; }
        public short CurForm { get; set; }
        public short DragType { get; set; }
        public short Rage { get; set; }
        public short SilTol { get; set; }
        // end dh
        public short[] TickTimer { get; set; }
        public short WarpCount { get; set; }
        public short VampGenA { get; set; }
        public short SpecType { get; set; }
        public short SpecPower { get; set; }
        public short[] LocHP { get; set; }
        public short[] Wpn { get; set; }
        public short[] Spl { get; set; }
        public short[] Cmbt { get; set; }
        public int[] Stance { get; set; }
        public short Beast { get; set; }
        public short Mounted { get; set; }
        public int Home { get; set; }
        public int Level { get; set; }
        public short Trust { get; set; }
        public int Played { get; set; }
        public DateTime Login { get; set; }
        public DateTime SaveTime { get; set; }
        public short Timer { get; set; }
        public short Wait { get; set; }
        public int PKill { get; set; }
        public int PDeath { get; set; }
        public int MKill { get; set; }
        public int MDeath { get; set; }
        public int Hit { get; set; }
        public int MaxHit { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Move { get; set; }
        public int MaxMove { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int Act { get; set; }
        public int Extra { get; set; }
        public int NewBits { get; set; }
        public int Special { get; set; }
        public int AffectedBy { get; set; }
        public int AffectedBy2 { get; set; }
        public int Position { get; set; }
        public int Practice { get; set; }
        public int CarryWeight { get; set; }
        public int CarryNumber { get; set; }
        public int SavingThrow { get; set; }
        public int Alignment { get; set; }
        public int HitRoll { get; set; }
        public int DamRoll { get; set; }
        public int Armor { get; set; }
        public int Wimpy { get; set; }
        public int Deaf { get; set; }
        public int[] Paradox { get; set; }
        public int[] DamCap { get; set; }
        public int MonkStuff { get; set; }
        public int MonkCrap { get; set; }
        public int[] MonkAb { get; set; }
        public short[] Chi { get; set; }
        public string Clan { get; set; }
        public int[] Gifts { get; set; }
        public int Garou1 { get; set; }
        public int Garou2 { get; set; }
        public short[] Gnosis { get; set; }
        public CharData Unveil { get; set; }
        public string ObjDesc { get; set; }
        public short MonkBlock { get; set; }
        public short[] Focus { get; set; }


    public const string PLAYER_DIR = "player\\";

        CharData(UserConnection conn)
        {
            Connection = conn;
            PCData = new ExpandoObject();
        }

        public static CharData Load(string name, UserConnection conn)
        {
            CharData retVal = null;
            if (!string.IsNullOrWhiteSpace(name))
            {
                string fileName = name.Trim();
                fileName = fileName.Substring(0, 1).ToUpperInvariant() + fileName.Substring(1).ToLowerInvariant();
                var path = Path.Combine(PLAYER_DIR, fileName);
                if (File.Exists(path))
                {
                    var contents = Encoding.ASCII.GetString(File.ReadAllBytes(path));
                    using (var sr = new StringReader(contents))
                    {
                        var done = false;
                        while (!done)
                        {
                            var letter = sr.ReadLetter();
                            if (letter == '*')
                            {
                                sr.ReadToEOL();
                                continue;
                            }

                            if (letter != '#')
                            {
                                throw new Exception("Load_char_obj: # not found.");
                            }

                            switch(sr.ReadWord().Trim())
                            {
                                case "PLAYERS":
                                    retVal = LoadCharData(sr, conn);
                                    break;
                                case "OBJECT":
                                case "END":
                                    done = true;
                                    break;
                                default:
                                    throw new Exception("Load_char_obj: bad section.");

                            }
                        }
                    }
                }

            }
            if (retVal == null)
            {
                conn.Disconnect();
            }
            return retVal;
        }

        static CharData LoadCharData(StringReader sr, UserConnection conn)
        {
            var ch = new CharData(conn);
            while (true)
            {
                var word = sr.ReadWord();
                switch(word)
                {
                    // A ----------------
                    case "Act": ch.Act = sr.ReadNumber(); break;
                    case "AffectedBy": ch.AffectedBy = sr.ReadNumber(); break;
                    case "Alignment": ch.Alignment = sr.ReadNumber(); break;
                    case "Armor": ch.Armor = sr.ReadNumber(); break;
                    case "Avatarmessage": ch.PCData.Avatarmessage = sr.ReadString(); break;
                    case "Awin": ch.PCData.Awins = sr.ReadNumber(); break;
                    case "Alos": ch.PCData.Alosses = sr.ReadNumber(); break;
                    case "Affect":
                    case "AffectData":
                        var aff = new AffectData();
                        if (word == "Affect")
                        {
                            aff.Type = sr.ReadShort();
                        }
                        else
                        {
                            aff.Type = (short)SkillType.Lookup(sr.ReadWord());
                        }
                        aff.Duration = sr.ReadShort();
                        aff.Modifier = sr.ReadShort();
                        aff.Location = sr.ReadShort();
                        aff.BitVector = sr.ReadNumber();
                        ch.Affected.Add(aff);
                        // TODO add to affect_free
                        break;
                    case "AttrMod":
                        ch.PCData.ModStr = sr.ReadNumber();
                        ch.PCData.ModInt = sr.ReadNumber();
                        ch.PCData.ModWis = sr.ReadNumber();
                        ch.PCData.ModDex = sr.ReadNumber();
                        ch.PCData.ModCon = sr.ReadNumber();
                        break;
                    case "AttrPerm":
                        ch.PCData.PermStr = sr.ReadNumber();
                        ch.PCData.PermInt = sr.ReadNumber();
                        ch.PCData.PermWis = sr.ReadNumber();
                        ch.PCData.PermDex = sr.ReadNumber();
                        ch.PCData.PermCon = sr.ReadNumber();
                        break;
                    case "Alias":
                        var ad = new AliasData();
                        ad.ShortN = sr.ReadString();
                        ad.LongN = sr.ReadString();
                        ch.PCData.Alias.Add(ad);
                        // add to alias_free
                        break;

                    // B ----------------
                    case "Bamfin": ch.PCData.Bamfin = sr.ReadString(); break;
                    case "Bamfout": ch.PCData.Bamfout = sr.ReadString(); break;
                    case "Beast": ch.Beast = sr.ReadShort(); break;
                    case "Bounty": ch.PCData.Bounty = sr.ReadNumber(); break;
                    case "Breath1": sr.ReadNumber(); break;
                    case "Breath2": sr.ReadNumber(); break;
                    case "Breath3": sr.ReadNumber(); break;
                    case "Breath4": sr.ReadNumber(); break;
                    case "Breath5": sr.ReadNumber(); break;
                }
            }
        }

        public bool Authenticate(string password)
        {
            return true;
        }
    }
}
