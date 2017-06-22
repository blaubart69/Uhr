using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class TimeWithAngle
    {
        public readonly Angle angle;
        public readonly TimePoint time;

        public TimeWithAngle(Angle angle, TimePoint time)
        {
            this.angle = angle;
            this.time = time;
        }

        public TimeWithAngle(byte h, byte m, byte s, Angle angle)
        {
            this.time = new TimePoint(h,m,s);
            this.angle = angle;
        }
    }
}
