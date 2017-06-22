using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class TimePoint
    {
        public readonly byte h;
        public readonly byte m;
        public readonly byte s;
        public readonly int f;

        public TimePoint(byte h, byte m, byte s)
            : this(h,m,s,0)
        {
        }

        public TimePoint(byte h, byte m, byte s, int f)
        {
            this.h = h;
            this.m = m;
            this.s = s;
            this.f = f;
        }
    }
}
