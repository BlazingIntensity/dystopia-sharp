using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class HelpData
    {
        public AreaData Area { get; set; }
        public short Level { get; set; }
        public string Keyword { get; set; }
        public string Text { get; set; }
        HelpData()
        {
        }

        static List<HelpData> helps = new List<HelpData>();

        static void AddHelp(HelpData help)
        {
            lock(helps)
            {
                // TODO SORT
                helps.Add(help);
            }
        }

        public static void LoadFromArea(StringReader sr)
        {
            while (true)
            {
                var help = new HelpData();
                help.Level = (short)sr.ReadNumber();

                help.Keyword = sr.ReadString();
                if (help.Keyword == "$") break;

                help.Text = sr.ReadString();
                if (string.IsNullOrWhiteSpace(help.Text)) continue;

                //if (keyword == "greeting") help_greeting = text;
                AddHelp(help);
            }
        }
    }
}
