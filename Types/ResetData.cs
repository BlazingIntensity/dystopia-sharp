using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    /*
     * Reset commands:
     *   '*': comment
     *   'M': read a mobile 
     *   'O': read an object
     *   'P': put object in object
     *   'G': give object to mobile
     *   'E': equip object to mobile
     *   'D': set state of door
     *   'R': randomize room exits
     *   'S': stop (end of list)
     */

    public class ResetData
    {
        // public ResetData Next { get; set; }
        public char Command { get; set; }
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }
        public int Arg3 { get; set; }

        public static void LoadFromArea(StringReader sr)
        {
            while (true)
            {
                var letter = sr.ReadLetter();

                if (letter == 'S') break;
                if (letter == '*')
                {
                    sr.ReadToEOL();
                    continue;
                }

                var rd = new ResetData { Command = letter };
                sr.ReadNumber(); // if_flag
                rd.Arg1 = sr.ReadNumber();
                rd.Arg2 = sr.ReadNumber();
                if (letter != 'G' && letter != 'R') rd.Arg3 = sr.ReadNumber();
                sr.ReadToEOL();

                Vnum lastObj = Vnum.None;
                Vnum lastRoom = Vnum.None;
                RoomDef roomData;
                MobileDef mobData;
                ObjectDef objData;
                ExitData exitData;

                switch (rd.Command)
                {
                    case 'M':
                        if (MobileDef.TryGetMobileDef((Vnum)rd.Arg1, out mobData) && RoomDef.TryGetRoomDef((Vnum)rd.Arg3, out roomData))
                        {
                            roomData.AddReset(rd);
                            lastRoom = roomData.Vnum;
                        }
                        break;

                    case 'O':
                        if (ObjectDef.TryGetObjectData((Vnum)rd.Arg1, out objData) && RoomDef.TryGetRoomDef((Vnum)rd.Arg3, out roomData))
                        {
                            roomData.AddReset(rd);
                            lastObj = roomData.Vnum;
                        }
                        break;

                    case 'P':
                        if (ObjectDef.TryGetObjectData((Vnum)rd.Arg1, out objData) && RoomDef.TryGetRoomDef(lastObj, out roomData))
                        {
                            roomData.AddReset(rd);
                        }
                        break;

                    case 'G':
                    case 'E':
                        if (ObjectDef.TryGetObjectData((Vnum)rd.Arg1, out objData) && RoomDef.TryGetRoomDef(lastRoom, out roomData))
                        {
                            roomData.AddReset(rd);
                            lastObj = lastRoom;
                        }
                        break;

                    case 'D':
                        if (rd.Arg2 < 0 ||
                            rd.Arg2 > 5 ||
                            !RoomDef.TryGetRoomDef((Vnum)rd.Arg1, out roomData) ||
                            !roomData.TryGetExit(rd.Arg2, out exitData) ||
                            !exitData.IsDoor)
                        {
                            throw new Exception($"Load_resets: 'D': exit {rd.Arg2} not door.");
                        }

                        switch(rd.Arg3)
                        {
                            case 0: break;
                            case 1:
                                exitData.RSFlags |= ExitFlags.Closed;
                                break;
                            case 2:
                                exitData.RSFlags |= ExitFlags.Closed | ExitFlags.Locked;
                                break;
                            default:
                                throw new Exception($"Load_resets: 'D': bad 'locks': {rd.Arg3}.");
                        }
                        break;

                    case 'R':
                        if (rd.Arg2 < 0 || rd.Arg2 > 6)
                        {
                            throw new Exception($"Load_resets: 'R': bad exit {rd.Arg2}.");
                        }

                        if (RoomDef.TryGetRoomDef((Vnum)rd.Arg2, out roomData))
                        {
                            roomData.AddReset(rd);
                        }
                        break;

                    default:
                        throw new Exception($"Load_resets: bad command '{rd.Command}'.");
                }

            }
        }
    }
}
