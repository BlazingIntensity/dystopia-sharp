using CryptSharp;
using dystopia_sharp.Classes;
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
        public PCData PCData { get; set; }
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
            //PCData = new ExpandoObject();
            Stance = new int[24];
            PCData = new PCData();
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
                    case "Avatarmessage": ch.PCData.AvatarMessage = sr.ReadString(); break;
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
                        ch.PCData.ModStr = sr.ReadShort();
                        ch.PCData.ModInt = sr.ReadShort();
                        ch.PCData.ModWis = sr.ReadShort();
                        ch.PCData.ModDex = sr.ReadShort();
                        ch.PCData.ModCon = sr.ReadShort();
                        break;
                    case "AttrPerm":
                        ch.PCData.PermStr = sr.ReadShort();
                        ch.PCData.PermInt = sr.ReadShort();
                        ch.PCData.PermWis = sr.ReadShort();
                        ch.PCData.PermDex = sr.ReadShort();
                        ch.PCData.PermCon = sr.ReadShort();
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
                    case "Boards":
                        var numBoards = sr.ReadNumber();
                        for (int i = 0; i < numBoards; ++i)
                        {
                            var boardname = sr.ReadWord();
                            var lastNote = sr.ReadNumberAsDateTime();

                            var board = BoardData.Lookup(boardname);
                            if (board == -1)
                            {
                                Content.log.Warn($"{ch.Name} had unknown board name: {boardname}. Skipped.");
                            }
                            else
                            {
                                ch.PCData.LastNote[i] = lastNote;
                            }
                        }
                        break;

                    // C ----------------
                    case "Clan": ch.Clan = sr.ReadString(); break;
                    case "Class": ch.Class_ = sr.ReadNumber(); break;
                    case "CurrentForm": ch.CurForm = sr.ReadShort(); break;
                    case "Combat":
                        ch.Cmbt = ReadArray(sr, _ => _.ReadShort(), 8);
                        break;
                    case "Chi":
                        ch.Chi = ReadArray(sr, _ => _.ReadShort(), 2);
                        break;
                    case "Conception":
                        ch.PCData.Conception = sr.ReadString();
                        break;
                    case "Condition":
                        ch.PCData.Condition = ReadArray(sr, _ => _.ReadShort(), 3);
                        break;
                    case "CPower":
                        ch.Power = ReadArray(sr, _ => _.ReadNumber(), 44);
                        break;
                    case "Cparents": ch.PCData.CParents = sr.ReadString(); break;
                    case "Cprompt": ch.CPrompt = sr.ReadString(); break;
                    case "Createtime": ch.CreateTime = sr.ReadString(); break;

                    // D ----------------
                    case "Damroll": ch.DamRoll = sr.ReadNumber(); break;
                    case "Deaf": ch.Deaf = sr.ReadNumber(); break;
                    case "Decapmessage": ch.PCData.DecapMessage = sr.ReadString(); break;
                    case "Demonic": sr.ReadNumber(); break;
                    case "Description": ch.Description = sr.ReadString(); break;
                    case "DiscRese": ch.PCData.DiscResearch = sr.ReadNumber(); break;
                    case "DiscPoin": ch.PCData.DiscPoints = sr.ReadNumber(); break;
                    case "Dragonaff": sr.ReadNumber(); break;
                    case "Dragonage": sr.ReadNumber(); break;
                    case "Disc": for (int i = 0; i < 11; ++i) sr.ReadNumber(); break;
                    case "Drowaff": sr.ReadNumber(); break;
                    case "Drowpwr": sr.ReadNumber(); break;
                    case "Drowmag": sr.ReadNumber(); break;

                    // E ----------------
                    case "Email": sr.ReadString(); break;
                    case "End": return ch;
                    case "Exhaustion": ch.PCData.Exhaustion = sr.ReadShort(); break;
                    case "Exp": ch.Exp = sr.ReadNumber(); break;
                    case "Explevel": ch.ExpLevel = sr.ReadNumber(); break;
                    case "Expgained": ch.ExpGained = sr.ReadNumber(); break;
                    case "Extra": ch.Extra = sr.ReadNumber(); break;

                    // F ----------------
                    case "FakeCon":
                        ch.PCData.FakeSkill = sr.ReadShort();
                        ch.PCData.FakeStance = sr.ReadShort();
                        ch.PCData.FakeHit = sr.ReadShort();
                        ch.PCData.FakeDam = sr.ReadShort();
                        ch.PCData.FakeAC = sr.ReadNumber();
                        ch.PCData.FakeHP = sr.ReadShort();
                        ch.PCData.FakeMana = sr.ReadShort();
                        ch.PCData.FakeMove = sr.ReadShort();
                        break;
                    case "Focus":
                        ch.Focus = ReadArray(sr, _ => _.ReadShort(), 2);
                        break;
                    case "Flag2": ch.Flag2 = sr.ReadNumber(); break;
                    case "Flag3": ch.Flag3 = sr.ReadNumber(); break;
                    case "Flag4": ch.Flag4 = sr.ReadNumber(); break;
                    case "Form": ch.Form = sr.ReadNumber(); break;

                    // G ----------------
                    case "Generation": ch.Generation = sr.ReadShort(); break;
                    case "Gnosis": ch.Gnosis = new short[Garou.GMAXIMUM] { sr.ReadShort() }; break;
                    case "Genes":
                        ch.PCData.Genes = ReadArray(sr, _ => _.ReadNumber(), 10);
                        break;
                    case "Garou1": ch.Garou1 = sr.ReadNumber(); break;
                    case "Garou2": ch.Garou2 = sr.ReadNumber(); break;
                    case "Gifts":
                        ch.Gifts = ReadArray(sr, _ => _.ReadNumber(), 21);
                        break;
                    case "Gold": ch.Gold = sr.ReadNumber(); break;

                    // H ----------------
                    case "Hitroll": ch.HitRoll = sr.ReadNumber(); break;
                    case "Home": ch.Home = sr.ReadNumber(); break;
                    case "Hatch": sr.ReadNumber(); break;
                    case "HpManaMove":
                        ch.Hit = sr.ReadNumber();
                        ch.MaxHit = sr.ReadNumber();
                        ch.Mana = sr.ReadNumber();
                        ch.MaxMana = sr.ReadNumber();
                        ch.Move = sr.ReadNumber();
                        ch.MaxMove = sr.ReadNumber();
                        break;

                    // I ----------------
                    case "Immune": ch.Immune = sr.ReadNumber(); break;
                    case "Itemaffect": ch.ItemAffect = sr.ReadNumber(); break;

                    // J ----------------
                    case "Jflags": ch.PCData.JFlags = sr.ReadNumber(); break;

                    // K ----------------
                    case "Kingdom": ch.PCData.Kingdom = sr.ReadNumber(); break;

                    // L ----------------
                    case "Language":
                        ch.PCData.Language = ReadArray(sr, _ => _.ReadNumber(), 2);
                        break;
                    case "Lasthost": ch.LastHost = sr.ReadString(); break;
                    case "Lastdecap1": ch.PCData.LastDecap[0] = sr.ReadString(); break;
                    case "Lastdecap2": ch.PCData.LastDecap[1] = sr.ReadString(); break;
                    case "Lasttime": ch.LastTime = sr.ReadString(); break;
                    case "Level": ch.Level = sr.ReadNumber(); break;
                    case "Levelexp": sr.ReadNumber(); break;
                    case "Locationhp":
                        ch.LocHP = ReadArray(sr, _ => _.ReadShort(), 7);
                        break;
                    case "Loginmessage": ch.PCData.LoginMessage = sr.ReadString(); break;
                    case "Logoutmessage": ch.PCData.LogoutMessage = sr.ReadString(); break;
                    case "LongDescr": ch.LongDescription = sr.ReadString(); break;
                    case "Lord": ch.Lord = sr.ReadString(); break;

                    // M ----------------
                    case "MageFlags": sr.ReadNumber(); break;
                    case "Monkab":
                        ch.MonkAb = ReadArray(sr, _ => _.ReadNumber(), 4);
                        break;

                    case "Meanparadox": ch.PCData.MeanParadoxCounter = sr.ReadShort(); break;
                    case "Monkstuff": ch.MonkStuff = sr.ReadNumber(); break;
                    case "Monkcrap": ch.MonkCrap = sr.ReadNumber(); break;
                    case "Marriage": ch.PCData.Marriage = sr.ReadString(); break;
                    case "Morph": ch.Morph = sr.ReadString(); break;

                    // N ----------------
                    case "Newbits": ch.NewBits = sr.ReadNumber(); break;
                    case "Name": sr.ReadToEOL(); break;

                    // O ----------------
                    case "Objvnum": ch.PCData.ObjVNum = sr.ReadVnum(); break;
                    case "ObjDesc": ch.ObjDesc = sr.ReadString(); break;

                    // P ----------------
                    case "Paradox":
                        ch.Paradox = ReadArray(sr, _ => _.ReadNumber(), 3);
                        break;
                    case "Parents": ch.PCData.Parents = sr.ReadString(); break;
                    case "Password": ch.PCData.Pwd = sr.ReadString(); break;
                    case "Played": ch.Played = sr.ReadNumber(); break;
                    case "Polyaff": ch.PolyAff = sr.ReadNumber(); break;
                    case "Power_Point": sr.ReadNumber(); break;
                    case "Power":
                        ch.PCData.Powers = ReadArray(sr, _ => _.ReadNumber(), 20);
                        break;
                    case "Poweraction": ch.PowerAction = sr.ReadString(); break;
                    case "Powertype": ch.PowerType = sr.ReadString(); break;
                    case "Position": ch.Position = sr.ReadNumber(); break;
                    case "Practice": ch.Practice = sr.ReadNumber(); break;
                    case "PkPdMkMd":
                        ch.PKill = sr.ReadNumber();
                        ch.PDeath = sr.ReadNumber();
                        ch.MKill = sr.ReadNumber();
                        ch.MDeath = sr.ReadNumber();
                        break;
                    case "Prompt": ch.Prompt = sr.ReadString(); break;

                    // Q ----------------
                    case "Quest": ch.PCData.Quest = sr.ReadNumber(); break;
                    case "Questsrun": ch.PCData.QuestsRun = sr.ReadNumber(); break;
                    case "Queststotal": ch.PCData.QuestsTotal = sr.ReadNumber(); break;

                    // R ----------------
                    case "Race": ch.PCData.Quest = sr.ReadNumber(); break;
                    case "Rage": ch.Rage = sr.ReadShort(); break;
                    case "Rank": ch.PCData.Rank = sr.ReadShort(); break;
                    case "Relrank": ch.PCData.RelRank = sr.ReadShort(); break;
                    case "Revision": ch.PCData.Revision = sr.ReadShort(); break;
                    case "Runecount": ch.PCData.RuneCount = sr.ReadShort(); break;
                    case "Room":
                        RoomDef room;
                        if (RoomDef.TryGetRoomDef(sr.ReadVnum(), out room)) ch.InRoom = room;
                        break;
                    case "Runes":
                        ReadArray(sr, _ => _.ReadNumber(), 4);
                        break;

                    // S ----------------
                    case "Smite": sr.ReadString(); break;
                    case "SavingThrow": ch.SavingThrow = sr.ReadNumber(); break;
                    case "Switchname": ch.PCData.SwitchName = sr.ReadString(); break;
                    case "SilTol": ch.SilTol = sr.ReadShort(); break;
                    case "Souls": ch.PCData.Souls = sr.ReadShort(); break;
                    case "Score":
                        ch.PCData.Score = ReadArray(sr, _ => _.ReadNumber(), 6);
                        break;
                    case "Sex": ch.Sex = (Gender)sr.ReadShort(); break;
                    case "ShortDescr": ch.ShortDescription = sr.ReadString(); break;
                    case "Security": ch.PCData.Security = sr.ReadNumber(); break;
                    case "Skill":
                        var value = sr.ReadShort();
                        var sn = SkillType.Lookup(sr.ReadWord());
                        if (sn >= 0) ch.PCData.Learned[sn] = value;
                        break;
                    case "Specpower": ch.SpecPower = sr.ReadShort(); break;
                    case "Spectype": ch.SpecType = sr.ReadShort(); break;
                    case "Special": ch.Special = sr.ReadNumber(); break;
                    case "Spells":
                        ch.Spl = ReadArray(sr, _ => _.ReadShort(), 5);
                        break;
                    case "Stage":
                        ch.PCData.Stage = ReadArray(sr, _ => _.ReadShort(), 3);
                        break;
                    case "Stance":
                        for (int i = 0; i < 12; ++i)
                        {
                            ch.Stance[i] = sr.ReadNumber();
                        }
                        break;
                    case "Stance2":
                        for (int i = 0; i < 12; ++i)
                        {
                            ch.Stance[i + 12] = sr.ReadNumber();
                        }
                        break;
                    case "StatAbility":
                        ch.PCData.StatAbility = ReadArray(sr, _ => _.ReadShort(), 4);
                        break;
                    case "StatAmount":
                        ch.PCData.StatAmount = ReadArray(sr, _ => _.ReadShort(), 4);
                        break;
                    case "StatDuration":
                        ch.PCData.StatDuration = ReadArray(sr, _ => _.ReadShort(), 4);
                        break;
                    case "Stats":
                        ch.PCData.Stats = ReadArray(sr, _ => _.ReadNumber(), 12);
                        break;

                    // T ----------------
                    case "Tiemessage": ch.PCData.TimeMessage = sr.ReadString(); break;
                    case "Trust": ch.Trust = sr.ReadShort(); break;
                    case "Title":
                        var title = sr.ReadString().Trim();
                        ch.PCData.Title = " " + title;
                        break;

                    // U ----------------
                    case "Upgradelevel": ch.PCData.UpgradeLevel = sr.ReadShort(); break;

                    // V ----------------
                    case "Vampaff": sr.ReadNumber(); break;
                    case "Vampgen": sr.ReadNumber(); break;
                    case "Vnum":
                        var mdvnum = sr.ReadVnum();
                        MobileDef md;
                        if (MobileDef.TryGetMobileDef(mdvnum, out md))
                        {
                            ch.IndexData = md;
                        }
                        break;

                    // W ----------------
                    case "Warps": ch.Warp = sr.ReadNumber(); break;
                    case "WarpCount": ch.WarpCount = sr.ReadShort(); break;
                    case "Weapons":
                        ch.Wpn = ReadArray(sr, _ => _.ReadShort(), 13);
                        break;
                    case "Wimpy": ch.Wimpy = sr.ReadShort(); break;
                    case "Wolf": sr.ReadShort(); break;
                    case "Wolfform":
                        sr.ReadNumber();
                        sr.ReadNumber();
                        break;

                    // X ----------------
                    case "XHitroll": ch.XHitRoll = sr.ReadNumber(); break;
                    case "XDamroll": ch.XDamRoll = sr.ReadNumber(); break;

                    default:
                        Content.log.Error($"no match.WORD: {word}");
                        sr.ReadToEOL();
                        break;
                }
            }
        }

        public bool Authenticate(string password)
        {
            bool good = false;
            var hash = Crypter.TraditionalDes.Crypt(password, Name.Substring(0, 2));
            good = hash == PCData.Pwd;
            return good;
        }

        static TType[] ReadArray<TType>(StringReader sr, Func<StringReader, TType> action, int size)
        {
            var array = new TType[size];
            for (int i = 0; i < size; ++i)
            {
                array[i] = action(sr);
            }
            return array;
        }
    }
}
