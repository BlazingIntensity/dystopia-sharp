using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public enum SunState : byte
    {
        Dark = 0,
        Rise,
        Light,
        Set
    }

    public enum SkyState : byte
    {
        Cloudless = 0,
        Cloudy,
        Raining,
        Lightning
    }

    public struct Weather
    {
        public long Pressure { get; set; }
        public long Change { get; set; }
        public SkyState Sky { get; set; }
        public SunState Sunlight { get; set; }

        public Weather(TimeInfo ti)
        {
            if (ti.Hour < 5) Sunlight = SunState.Dark;
            else if (ti.Hour < 6) Sunlight = SunState.Rise;
            else if (ti.Hour < 19) Sunlight = SunState.Light;
            else if (ti.Hour < 20) Sunlight = SunState.Set;
            else Sunlight = SunState.Dark;

            Change = 0;
            Pressure = 960;
            if (ti.Month >= 7 && ti.Month <= 12)
                Pressure += Content.Random.Next(1, 50);
            else
                Pressure += Content.Random.Next(1, 80);

            if (Pressure <= 980) Sky = SkyState.Lightning;
            else if (Pressure <= 1000) Sky = SkyState.Raining;
            else if (Pressure <= 1020) Sky = SkyState.Cloudy;
            else Sky = SkyState.Cloudless;

        }
    }
}
