using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public struct TimeInfo
    {
        public long Hour { get; set; }
        public long Day { get; set; }
        public long Month { get; set; }
        public long Year { get; set; }

        public TimeInfo(DateTime now)
        {
            var currentTime = now.Ticks / TimeSpan.TicksPerSecond;
            long lhour, lday, lmonth;

            lhour = currentTime / 3600;
            Hour = lhour % 24;
            lday = lhour / 24;
            Day = lday % 35;
            lmonth = lday / 35;
            Month = lmonth % 17;
            Year = lmonth / 17;
        }
    }
}
