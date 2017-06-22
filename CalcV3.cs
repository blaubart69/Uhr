using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class CalcV3 : IAngleCalc
    {
        public Angle Compute(TimePoint tp)
        {
            const double FractionsPerSecond     =                       1000;
            const double FractionsPerMinute     = FractionsPerSecond    * 60;
            const double FractionsPerHour       = FractionsPerMinute    * 60;
            const double FractionsPer12Hour     = FractionsPerHour      * 12;

            double SecAngle  =                                                       (tp.s * FractionsPerSecond + tp.f) / FractionsPerMinute    * 360;
            double MinAngle  =                           (tp.m * FractionsPerMinute + tp.s * FractionsPerSecond + tp.f) / FractionsPerHour      * 360;
            double HourAngle = (tp.h * FractionsPerHour + tp.m * FractionsPerMinute + tp.s * FractionsPerSecond + tp.f) / FractionsPer12Hour    * 360;

            return new Angle(HourAngle, MinAngle, SecAngle);
        }

        public IEnumerable<TimeWithAngle> Values()
        {
            for (byte h = 0; h < 12; h++)
            {
                for (byte m = 0; m < 60; m++)
                {
                    for (byte s = 0; s < 60; s++)
                    {
                        for (int f = 0; f < 1000; f++)
                        {
                            TimePoint tp = new TimePoint(h, m, s, f);
                            Angle a = Compute(tp
                                );
                            yield return new TimeWithAngle(a, tp);
                        }
                    }
                }
            }
        }
    }
}
