using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    public class Angle
    {
        public readonly double hour;
        public readonly double min;
        public readonly double sec;

        private double? _diff;

        public Angle(double HourAngle, double MinuteAngle, double SecAngle)
        {
            hour = HourAngle;
            min = MinuteAngle;
            sec = SecAngle;
            _diff = null;
        }

        public double Diff
        {
            get
            {
                if (!_diff.HasValue)
                {
                    double a = hour;
                    double b = min;
                    double c = sec;
                    Sort3(ref a, ref b, ref c);

                    double d1 = Math.Abs(120d - (b - a));
                    double d2 = Math.Abs(120d - (c - b));
                    double d3 = Math.Abs(120d - (360d - c + a));

                    _diff = d1 + d2 + d3;
                }

                return _diff.Value;
            }
        }

        public static void Sort3(ref double a, ref double b, ref double c)
        {
            if (a > c) Swap(ref a, ref c);
            if (a > b) Swap(ref a, ref b);
            //Now the smallest element is the first one. Just check the 2-nd and 3-rd
            if (b > c) Swap(ref b, ref c);
        }

        public static void Swap(ref double a, ref double b)
        {
            double hlp = b;
            b = a;
            a = hlp;
        }

        public double Diff_old
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
