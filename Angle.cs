using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class Angle
    {
        public readonly double hour;
        public readonly double min;
        public readonly double sec;

        public Angle(double HourAngle, double MinuteAngle, double SecAngle)
        {
            hour = HourAngle;
            min = MinuteAngle;
            sec = SecAngle;
        }

        public double Diff
        {
            get
            {
                double[] arr = new double[3] { hour, min, sec };
                Array.Sort(arr);

                double d1 = Math.Abs(120d - (arr[1] - arr[0]));
                double d2 = Math.Abs(120d - (arr[2] - arr[1]));
                double d3 = Math.Abs(120d - (360d - arr[2] + arr[0]));

                double diff = d1 + d2 + d3;

                return diff;
            }
        }
    }
}
