using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class CalcV2 : IAngleCalc
    {
        const double SecondsPer12Hour  = 3600 * 12;
        const double SecondsPerHour    = 60 * 60;
        const double SecondsPerMinute  =      60 ;

        public Angle Compute(TimePoint tp)
        {
            int h = tp.h;
            int m = tp.m;
            int s = tp.s;

            return new Angle(
                HourAngle:      (double)(h * 3600 + m * 60 + s) / SecondsPer12Hour  * 360d,
                MinuteAngle:    (double)(           m * 60 + s) / SecondsPerHour    * 360d,
                SecAngle:       (double)(                    s) / SecondsPerMinute  * 360d);
        }
        public IEnumerable<TimeWithAngle> Values()
        {
            for (byte h = 0; h < 12; h++)
            {
                for (byte m = 0; m < 60; m++)
                {
                    for (byte s = 0; s < 60; s++)
                    {
                        TimePoint tp = new TimePoint(h, m, s);
                        Angle a = Compute(tp);
                        yield return new TimeWithAngle(a, tp);
                    }
                }
            }
        }

    }
}
