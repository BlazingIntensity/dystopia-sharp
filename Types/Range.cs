using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class Range<T>
    {
        public Range(T min, T max)
        {
            Min = min;
            max = Max;
        }

        public Range() { }

        public T Min { get; set; }
        public T Max { get; set; }
    }
}
