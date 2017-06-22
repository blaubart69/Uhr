using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class CalcV1 : IAngleCalc
    {
        const int SecondsPer12Hour = 3600 * 12;
        const int SecondsPerHour = 60 * 60;

        public IEnumerable<TimeWithAngle> Values()
        {
            ulong TicksPer12Hours = SecondsPer12Hour;

            for (ulong s = 0; s <= TicksPer12Hours; s++)
            {
                Angle a = Calc1((ulong)s, TicksPer12Hours);
                yield return new TimeWithAngle(0, 0, 0, a);
            }
        }
        static Angle Calc1(ulong Ticks, ulong TicksPer12Hours)
        {

            double hourAngle = (double)Ticks / (double)TicksPer12Hours * 360d;

            ulong TicksPerHour = TicksPer12Hours / 12;

            ulong MinutesInticks = Ticks % TicksPerHour;
            double MinAngle = (double)MinutesInticks / (double)TicksPerHour * 360d;

            ulong TicksPerMinute = TicksPerHour / 60;
            ulong SecondsInTicks = MinutesInticks % TicksPerMinute;
            double SecAngle = (double)SecondsInTicks / 60d * 360d;

            return new Angle(hourAngle, MinAngle, SecAngle);
        }

        public Angle Compute(TimePoint tp)
        {
            throw new NotImplementedException();
        }
    }
}
