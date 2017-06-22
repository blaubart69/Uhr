using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    class Program
    {
        static void Main(string[] args)
        {
            TimePoint tp = null;
            IAngleCalc ArgsCalc = null;
            if (args.Length == 3)
            {
                tp = new TimePoint(byte.Parse(args[0]), byte.Parse(args[1]), byte.Parse(args[2]));
                ArgsCalc = new CalcV2();
            }
            else if (args.Length == 4)
            {
                tp = new TimePoint(byte.Parse(args[0]), byte.Parse(args[1]), byte.Parse(args[2]), int.Parse(args[3]));
                ArgsCalc = new CalcV3();
            }

            if ( tp != null )
            {
                Console.WriteLine($"computing with {ArgsCalc.ToString()}");
                Print2(new TimeWithAngle( ArgsCalc.Compute(tp), tp ));
                return;
            }

            var start = DateTime.Now;

            //IAngleCalc AngelCalculator = new CalcV2();
            IAngleCalc AngelCalculator = new CalcV3();
            foreach ( var timeAngle in AngelCalculator.Values().Where( ta => ta.angle.Diff < 10.0D)  ) //.OrderBy( a => a.Diff ) )
            {
                Print2(timeAngle);
            }

            Console.Error.WriteLine("Duration: {0}", new TimeSpan(DateTime.Now.Ticks - start.Ticks));
        }

        static void Print(TimeWithAngle TimeAngle)
        {
            Console.WriteLine("{0,12:##0.000000}\t{1,10:##0.000000}\t{2,10:##0.000000}\t{3,10:##0.000000}\t{4,2}\t{5,2}\t{6,2}", // \t{7,7:##0.0}\t{8,7:##0.0}\t{9,7:##0.0}",
                TimeAngle.angle.Diff,
                TimeAngle.angle.hour,
                TimeAngle.angle.min,
                TimeAngle.angle.sec,
                TimeAngle.time.h,
                TimeAngle.time.m,
                TimeAngle.time.s);
        }
        static void Print2(TimeWithAngle TimeAngle)
        {
            Console.WriteLine("{0:F12}\t{1:F12}\t{2:F12}\t{3:F12}\t{4,2}\t{5,2}\t{6,2}\t{7,3}", // \t{7,7:##0.0}\t{8,7:##0.0}\t{9,7:##0.0}",
                TimeAngle.angle.Diff,
                TimeAngle.angle.hour,
                TimeAngle.angle.min,
                TimeAngle.angle.sec,
                TimeAngle.time.h,
                TimeAngle.time.m,
                TimeAngle.time.s,
                TimeAngle.time.f);
        }

    }
}
