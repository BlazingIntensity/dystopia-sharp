using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using dystopia_sharp.Types;

namespace dystopia_sharp
{
    public class Content
    {
        public static readonly Logger log = Logger.Create("ContentLogger");
        const string areaList = "area.lst";
        public static TimeInfo TimeInfo { get; private set; }
        public static Weather Weather { get; private set; }
        public static DateTime Now { get; private set; }
        static readonly Random seeds = new Random();
        static int GetSeed()
        {
            lock(seeds)
            {
                return seeds.Next();
            }
        }

        [ThreadStatic]
        static Random random;
        public static Random Random
        {
            get
            {
                if (random == null)
                {
                    random = new Random(GetSeed());
                }
                return random;
            }
        }

        static void SetTimeAndWeather()
        {
            TimeInfo = new TimeInfo(Now);
            Weather = new Weather(TimeInfo);
        }

        static bool LoadAreaFiles()
        {
            string listContents;
            try
            {
                listContents = Encoding.ASCII.GetString(File.ReadAllBytes(areaList));
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return false;
            }

            using (var sr = new StringReader(listContents))
            {
                for (;;)
                {
                    var curFile = sr.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(curFile)) continue;
                    if (curFile.StartsWith("$")) break;

                    if (curFile.StartsWith("-"))
                    {
                        // ??????
                        // fpArea = stdin;
                        continue;
                    }

                    log.Info($"loadding {curFile}");
                    string areaContents;
                    try
                    {
                        areaContents = Encoding.ASCII.GetString(File.ReadAllBytes(curFile));
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message);
                        return false;
                    }


                    using (var ar = new StringReader(areaContents))
                    {
                        AreaData lastArea = null;
                        for (;;)
                        {
                            var word = ar.ReadWord();
                            if (!word.StartsWith("#")) return false;

                            word = word.Substring(1);
                            if (word.StartsWith("$")) break;

                            switch (word)
                            {
                                case "AREA":
                                    lastArea = AreaData.Load(ar, curFile);
                                    break;
                                case "HELPS":
                                    HelpData.LoadFromArea(ar);
                                    break;
                                case "MOBILES":
                                    MobileDef.LoadFromArea(ar, lastArea);
                                    break;
                                case "OBJECTS":
                                    ObjectDef.LoadFromArea(ar, lastArea);
                                    break;
                                case "RESETS":
                                    ResetData.LoadFromArea(ar);
                                    break;
                                case "ROOMS":
                                    RoomDef.LoadFromArea(ar, lastArea);
                                    break;
                                case "SHOPS":
                                    ShopData.LoadFromArea(ar);
                                    break;
                                case "SPECIALS":
                                    SpecType.LoadFromArea(ar);
                                    break;
                                // OLC
                                case "AREADATA":
                                    lastArea = AreaData.NewLoad(ar, curFile);
                                    break;
                                // OLC 1.1b
                                case "ROOMDATA":
                                    RoomDef.NewLoadFromArea(ar, lastArea);
                                    break;
                                default:
                                    log.Error($"Boot_db: bad section name '{word}'.");
                                    return false;
                            }
                        }
                    }
                }

                return true;
            }
        }

        public static void Initialize(DateTime now, bool copyover)
        {
            Now = now;
            SetTimeAndWeather();
            SkillType.AssignGSNs();
            LoadAreaFiles();

            /*
             * Fix up exits.
             * Declare db booting over.
             * Reset all areas once.
             * Load up the notes file.
             */
#if false
            fix_exits();
            area_update();
            load_bans();
            load_topboard();
            load_leaderboard();
            load_kingdoms();
            load_boards();
            save_notes();
            load_disabled();
#endif
            if (copyover) ActWiz.CopyoverRecover();
        }
    }
}
