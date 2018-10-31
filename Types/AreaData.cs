using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    [Flags]
    public enum AreaFlags : short
    {
        None = 0,
        Changed = 1 << 0,
        Added = 1 << 1,
        Loading = 1 << 2,
        Verbose = 1 << 3
    }
    public class AreaData
    {
        // Name of the zrea
        public string Name { get; set; }
        // Where recall takes you if you're in this area
        public Vnum Recall { get; set; }
        // How long since the last tick
        public int Age { get; set; }
        // Number of players in the area
        public int NPlayer { get; set; }
        // Filename of the area
        public string FileName { get; set; }
        // Who helped build the area
        public string Builders { get; set; }
        // Who can edit the area
        public int Security { get; set; }
        // Vnum range for the area
        public Range<Vnum> Vnums { get; set; }
        // Area Vnum (i think this is just the index into the linked list)
        public Vnum Vnum { get; set; }
        // Area Flags
        public AreaFlags AreaFlags { get; set; }

        AreaData()
        {
        }

        static List<AreaData> areas = new List<AreaData>();

        static void AddArea(AreaData newData)
        {
            lock (areas)
            {
                newData.Vnum = (Vnum)areas.Count;
                areas.Add(newData);
                newData.AreaFlags &= ~AreaFlags.Loading;
            }
        }

        public static AreaData Load(StringReader sr, string fileName)
        {
            var name = sr.ReadString();
            Content.log.Info(name);
            var newData = new AreaData
            {
                Name = name,
                Age = 15,
                NPlayer = 0,
                AreaFlags = AreaFlags.Loading,
                Security = 3,
                Builders = "None",
                Vnums = new Range<Vnum>(0, 0),
                FileName = fileName
            };
            AddArea(newData);

            return newData;
        }

        public static AreaData NewLoad(StringReader sr, string filename)
        {
            var newData = new AreaData
            {
                Age = 15,
                FileName = filename,
                Name = "New Area",
                Security = 3,
                Recall = Vnum.Temple
            };

            while (true)
            {
                string word;
                if (sr.Peek() == -1)
                {
                    word = "End";
                }
                else
                {
                    word = sr.ReadWord();
                }

                switch (word)
                {
                    case "Name":
                        newData.Name = sr.ReadString();
                        break;
                    case "Security":
                        newData.Security = sr.ReadNumber();
                        break;
                    case "VNUMs":
                        var min = sr.ReadVnum();
                        newData.Vnums = new Range<Vnum>(min, sr.ReadVnum());
                        break;
                    case "End":
                        AddArea(newData);
                        return newData;
                    case "Builders":
                        newData.Builders = sr.ReadString();
                        break;
                    case "Recall":
                        newData.Recall = sr.ReadVnum();
                        break;
                }
            }
        }
    }
}