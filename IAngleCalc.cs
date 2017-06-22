using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uhr
{
    interface IAngleCalc
    {
        IEnumerable<TimeWithAngle> Values();
        Angle Compute(TimePoint tp);
    }
}
