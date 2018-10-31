using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class RoomDef
    {
        // public RoomDef Next { get; set; }
        // public RoomDef NextRoom { get; set; }

        public List<CharData> People { get; set; }
        public List<ObjectData> Contents { get; set; }
        public List<ExtraDescrData> ExtraDescr { get; set; }
        public AreaData Area { get; set; }
        public ExitData[] Exits { get; set; }
        public List<RoomTextData> RoomText { get; set; }
        public List<ResetData> Resets { get; set; }

        public string[] Track { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Vnum Vnum { get; set; }
        public int RoomFlags { get; set; }
        public short Light { get; set; }
        public short Blood { get; set; }
        public short[] TrackDir { get; set; }
        public short SectorType { get; set; }
        public short[] TickTimer { get; set; }

        static readonly List<RoomDef> rooms = new List<RoomDef>();

        public const int MAX_RTIMER = 30;

        public RoomDef()
        {
            Resets = new List<ResetData>();
            Exits = new ExitData[6];
            Track = new string[5];
            TrackDir = new short[5];
            TickTimer = new short[MAX_RTIMER];
            ExtraDescr = new List<ExtraDescrData>();
            RoomText = new List<RoomTextData>();
        }

        public static bool TryGetRoomDef(Vnum vnum, out RoomDef retVal)
        {
            lock (rooms)
            {
                retVal = rooms.Find(md => md.Vnum == vnum);
                return retVal != null;
            }

        }

        public void AddReset(ResetData rd)
        {
            lock (Resets)
            {
                Resets.Add(rd);
            }
        }

        public bool TryGetExit(int index, out ExitData retVal)
        {
            if (index < 0 || index > 6)
            {
                retVal = null;
            }
            else
            {
                retVal = Exits[index];
            }

            return retVal != null;
        }

        public static void LoadFromArea(StringReader sr, AreaData area)
        {
            if (area == null)
            {
                throw new Exception($"Load_resets: no #AREA seen yet.");
            }

            while (true)
            {
                var letter = sr.ReadLetter();
                if (letter != '#')
                {
                    throw new Exception("Load_rooms: # not found.");
                }

                var vnum = sr.ReadVnum();
                if (vnum == Vnum.None) break;

                RoomDef existing;
                if (TryGetRoomDef(vnum, out existing))
                {
                    throw new Exception($"Load_rooms: vnum {vnum} duplicated.");
                }

                var rd = new RoomDef
                {
                    Area = area,
                    Vnum = vnum
                };

                rd.Name = sr.ReadString();
                rd.Description = sr.ReadString();
                sr.ReadNumber(); // Area number
                rd.RoomFlags = sr.ReadNumber();
                rd.SectorType = sr.ReadShort();

                while (true)
                {
                    letter = sr.ReadLetter();

                    if (letter == 'S') break;

                    switch (letter)
                    {
                        case 'D':
                            var door = sr.ReadNumber();
                            if (door < 0 || door > 5)
                            {
                                throw new Exception($"Fread_rooms: vnum {vnum} has bad door number.");
                            }

                            var exit = new ExitData();
                            exit.Description = sr.ReadString();
                            exit.Keyword = sr.ReadString();
                            var locks = sr.ReadNumber();
                            exit.Key = sr.ReadVnum();
                            exit.Vnum = sr.ReadVnum();

                            switch (locks)        /* OLC exit_info to rs_flags. */
                            {
                                case 1: exit.RSFlags = ExitFlags.IsDoor; break;
                                case 2: exit.RSFlags = ExitFlags.IsDoor | ExitFlags.PickProof; break;
                            }

                            rd.Exits[door] = exit;
                            break;

                        case 'E':
                            var ed = new ExtraDescrData();
                            ed.Keyword = sr.ReadString();
                            ed.Description = sr.ReadString();
                            rd.ExtraDescr.Add(ed);
                            break;

                        case 'T':
                            var rt = new RoomTextData();
                            rt.Input = sr.ReadString();
                            rt.Output = sr.ReadString();
                            rt.CHOutput = sr.ReadString();
                            rt.Name = sr.ReadString();
                            rt.Type = sr.ReadNumber();
                            rt.Power = sr.ReadNumber();
                            rt.Mob = sr.ReadNumber();

                            rd.RoomText.Add(rt);
                            break;

                        default:
                            throw new Exception($"Load_rooms: vnum {vnum} has flag not 'DES'.");
                    }
                }

                // TODO ?????????????????????

                //iHash = vnum % MAX_KEY_HASH;
                //pRoomIndex->next = room_index_hash[iHash];
                //room_index_hash[iHash] = pRoomIndex;
                //pRoomIndex->next_room = room_list;
                //room_list = pRoomIndex;
                //top_room++;
                //top_vnum_room = top_vnum_room < vnum ? vnum : top_vnum_room; /* OLC */
                //assign_area_vnum(vnum);
            }
        }

        public static void NewLoadFromArea(StringReader sr, AreaData area)
        {
            if (area == null)
            {
                throw new Exception($"Load_resets: no #AREA seen yet.");
            }

            while (true)
            {
                var letter = sr.ReadLetter();
                if (letter != '#')
                {
                    throw new Exception("Load_rooms: # not found.");
                }

                var vnum = sr.ReadVnum();
                if (vnum == Vnum.None) break;

                RoomDef existing;
                if (TryGetRoomDef(vnum, out existing))
                {
                    throw new Exception($"Load_rooms: vnum {vnum} duplicated.");
                }

                var rd = new RoomDef
                {
                    Area = area,
                    Vnum = vnum
                };

                rd.Name = sr.ReadString();
                rd.Description = sr.ReadString();
                sr.ReadNumber(); // Area number
                rd.RoomFlags = sr.ReadNumber();
                rd.SectorType = sr.ReadShort();

                while (true)
                {
                    letter = sr.ReadLetter();

                    if (letter == 'S' || letter == 's') break;

                    switch (letter)
                    {
                        case 'D':
                            var door = sr.ReadNumber();
                            if (door < 0 || door > 5)
                            {
                                throw new Exception($"Fread_rooms: vnum {vnum} has bad door number.");
                            }

                            var exit = new ExitData();
                            exit.Description = sr.ReadString();
                            exit.Keyword = sr.ReadString();
                            var locks = sr.ReadNumber();
                            exit.ExitInfo = locks;
                            exit.RSFlags = (ExitFlags)locks;
                            exit.Key = sr.ReadVnum();
                            exit.Vnum = sr.ReadVnum();
                            rd.Exits[door] = exit;
                            break;

                        case 'E':
                            var ed = new ExtraDescrData();
                            ed.Keyword = sr.ReadString();
                            ed.Description = sr.ReadString();
                            rd.ExtraDescr.Add(ed);
                            break;

                        case 'T':
                            var rt = new RoomTextData();
                            rt.Input = sr.ReadString();
                            rt.Output = sr.ReadString();
                            rt.CHOutput = sr.ReadString();
                            rt.Name = sr.ReadString();
                            rt.Type = sr.ReadNumber();
                            rt.Power = sr.ReadNumber();
                            rt.Mob = sr.ReadNumber();

                            rd.RoomText.Add(rt);
                            break;

                        default:
                            throw new Exception($"Load_rooms: vnum {vnum} has flag not 'DES'.");
                    }
                }

                // TODO ?????????????????????

                //iHash = vnum % MAX_KEY_HASH;
                //pRoomIndex->next = room_index_hash[iHash];
                //room_index_hash[iHash] = pRoomIndex;
                //top_room++;
                //top_vnum_room = top_vnum_room < vnum ? vnum : top_vnum_room;
                //assign_area_vnum(vnum);
            }
        }

        public static void FixExits()
        {

        }
    }
}
