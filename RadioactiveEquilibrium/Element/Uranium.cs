using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveEquilibrium.Element
{
    public class Uranium : BaseElement
    {
        public override ulong HalfLifeSec => (ulong)(2.455 * Math.Pow(10, 5) * YEAR_TO_SEC);

        public Uranium(BaseElement disintegrationTo, double startAmount = 0) : base(disintegrationTo, startAmount)
        {
        }
    }
}
