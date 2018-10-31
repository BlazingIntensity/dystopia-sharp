using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public enum ItemType : short
    {
        None = 0,
        Light,
        Scroll,
        Wand,
        Staff,
        Treasure = 8,
        Armor,
        Potion,
        Furniture = 12,
        Trash,
        Container = 15,
        DrinkCon = 17,
        Key,
        Food,
        Money,
        Boat = 22,
        CorpseNPC,
        CorpsePC,
        Fountain,
        Pill,
        Portal,
        Egg,
        Voodoo,
        Stake,
        Missile,/* Ammo vnum, cur, max, type */
        Ammo,/* ???, dam min, dam max, type */
        Quest,
        QuestCard,
        QuestMachine,
        Symbol,
        Book,
        Page,
        Tool,
        Wall,
        Copper,
        Iron,
        Steel,
        Adamantite,
        Gemstone,
        Hilt,
        DToken,
        Head,
        CookingPot = 50,
        DragonGem,
        WGate,
        Instrument
    }

    [Flags]
    public enum ExtraFlags : int
    {
        None = 0,
        Glow = 1 << 0,
        Hum = 1 << 1,
        Thrown = 1 << 2,
        Keep = 1 << 3,
        Vanish = 1 << 4,
        Invis = 1 << 5,
        Magic = 1 << 6,
        NoDrop = 1 << 7,
        Bless = 1 << 8,
        AntiGood = 1 << 9,
        AntiEvil = 1 << 10,
        AntiNeutral = 1 << 11,
        Prototype = 1 << 11,
        NoRemove = 1 << 12,
        Inventory = 1 << 13,
        Loyal = 1 << 14,
        ShadowPlane = 1 << 15,
        Merchant = 1 << 16
    }

    public class ObjectDef
    {
        // public ObjectData Next { get; set; }
        public List<ExtraDescrData> ExtraDescr { get; set; }
        public List<AffectData> Affected { get; set; }
        public AreaData Area { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CHPowerOn { get; set; }
        public string CHPowerOff { get; set; }
        public string CHPowerUse { get; set; }
        public string VictimPowerOn { get; set; }
        public string VictimPowerOff { get; set; }
        public string VictimPowerUse { get; set; }
        public string QuestMaker { get; set; }
        public string QuestOwner { get; set; }
        public Vnum Vnum { get; set; }
        public ItemType ItemType { get; set; }
        public ExtraFlags ExtraFlags { get; set; }
        public short ExtraFlags2 { get; set; }
        public int WearFlags { get; set; }
        public short Count { get; set; }
        public short Weight { get; set; }
        public short WeapFlags { get; set; }
        public int SpecType { get; set; }
        public int SpecPower { get; set; }
        public short Condition { get; set; }
        public short Toughness { get; set; }
        public short Reistance { get; set; }
        public int Quest { get; set; }
        public short Points { get; set; }
        public int Cost { get; set; } // Unused
        public int[] Value { get; set; }

        static readonly List<ObjectDef> objects = new List<ObjectDef>();

        ObjectDef()
        {
            Value = new int[4];
            Affected = new List<AffectData>();
            ExtraDescr = new List<ExtraDescrData>();
        }

        public static bool TryGetObjectData(Vnum vnum, out ObjectDef retVal)
        {
            lock (objects)
            {
                retVal = objects.Find(md => md.Vnum == vnum);
                return retVal == null;
            }
        }

        public static void LoadFromArea(StringReader sr, AreaData area)
        {
            if (area == null)
            {
                throw new Exception("Load_objects: no #AREA seen yet.");
            }

            while (true)
            {
                var letter = sr.ReadLetter();
                if (letter != '#')
                {
                    throw new Exception("Load_objects: # not found.");
                }

                var vnum = sr.ReadVnum();
                if (vnum == Vnum.None) break;

                ObjectDef existing;
                if (!TryGetObjectData(vnum, out existing))
                {
                    throw new Exception($"Load_objects: vnum % {vnum} duplicated.");
                }

                var od = new ObjectDef
                {
                    Vnum = vnum,
                    Area = area
                };

                od.Name = sr.ReadString();
                // TODO upper first char
                od.ShortDescription = sr.ReadString();
                // TODO upper first char
                od.Description = sr.ReadString();
                sr.ReadString(); // Action description

                od.ItemType = (ItemType)sr.ReadShort();
                od.ExtraFlags = (ExtraFlags)sr.ReadNumber();
                od.WearFlags = sr.ReadNumber();

                switch (od.ItemType)
                {
                    case ItemType.Wand:
                    case ItemType.Staff:
                        od.Value[0] = sr.ReadNumber();
                        od.Value[1] = sr.ReadNumber();
                        od.Value[2] = sr.ReadNumber();
                        od.Value[3] = SkillType.Lookup(sr.ReadWord());
                        break;
                    case ItemType.Potion:
                    case ItemType.Pill:
                    case ItemType.Scroll:
                        od.Value[0] = sr.ReadNumber();
                        od.Value[1] = SkillType.Lookup(sr.ReadWord());
                        od.Value[2] = SkillType.Lookup(sr.ReadWord());
                        od.Value[3] = SkillType.Lookup(sr.ReadWord());
                        break;
                    default:
                        od.Value[0] = sr.ReadNumber();
                        od.Value[1] = sr.ReadNumber();
                        od.Value[2] = sr.ReadNumber();
                        od.Value[3] = sr.ReadNumber();
                        break;
                }

                od.Weight = sr.ReadShort();
                od.Cost = sr.ReadNumber();

                sr.ReadNumber(); // Cost per day

                //if (od.ItemType == ItemType.Potion)
                //{
                //    od.ExtraFlags |= ExtraFlags.NoDrop;
                //}

                while (true)
                {
                    bool done = false;
                    switch(sr.PeekLetter())
                    {
                        case 'A':
                            sr.ReadLetter();
                            var aff = new AffectData
                            {
                                Type = -1,
                                Duration = -1
                            };
                            aff.Location = sr.ReadShort();
                            aff.Modifier = sr.ReadShort();
                            od.Affected.Add(aff);
                            // top_affect++;
                            break;
                        case 'E':
                            sr.ReadLetter();
                            var ed = new ExtraDescrData();
                            ed.Keyword = sr.ReadString();
                            ed.Description = sr.ReadString();
                            od.ExtraDescr.Add(ed);
                            //top_ed++;
                            break;
                        case 'Q':
                            sr.ReadLetter();
                            od.CHPowerOn = sr.ReadString();
                            od.CHPowerOff = sr.ReadString();
                            od.CHPowerUse = sr.ReadString();
                            od.VictimPowerOn = sr.ReadString();
                            od.VictimPowerOff = sr.ReadString();
                            od.VictimPowerUse = sr.ReadString();
                            od.SpecType = sr.ReadNumber();
                            od.SpecPower = sr.ReadNumber();
                            break;
                        default:
                            done = true;
                            break;
                    }
                    if (done) break;
                }

                // ?????
                switch(od.ItemType)
                {
                    case ItemType.Pill:
                    case ItemType.Potion:
                    case ItemType.Scroll:
                    case ItemType.Staff:
                    case ItemType.Wand:
                        break;
                }

                switch(od.Vnum)
                {
                    case (Vnum)3375:
                        // CHAOS = true;
                        break;
                    case (Vnum)29515:
                        // VISOR = true;
                        break;
                    case (Vnum)29512:
                        // DARKNESS = true;
                        break;
                    case (Vnum)29505:
                        // SPEED = true;
                        break;
                    case (Vnum)29518:
                        // BRACELET = true;
                        break;
                    case (Vnum)29504:
                        // TORC = true;
                        break;
                    case (Vnum)29514:
                        // ARMOUR = true;
                        break;
                    case (Vnum)29516:
                        // CLAWS = true;
                        break;
                    case (Vnum)29555:
                        // ITEMAFFMANTIS = true;
                        break;
                    case (Vnum)2654:
                        // ITEMAFFENTROPY = true;
                        break;
                    case (Vnum)29598:
                        // ITEMAFFENTROPY = true;
                        break;
                }


                // TODO ???????

                //iHash = vnum % MAX_KEY_HASH;
                //pObjIndex->next = obj_index_hash[iHash];
                //obj_index_hash[iHash] = pObjIndex;
                //top_obj_index++;
                //top_vnum_obj = top_vnum_obj < vnum ? vnum : top_vnum_obj;  /* OLC */
                //assign_area_vnum(vnum);                                  /* OLC */

            }
        }
    }
}
