using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveEquilibrium.Element
{
    public class Radium : BaseElement
    {
        public override ulong HalfLifeSec => (ulong)(1.6 * Math.Pow(10, 3) * YEAR_TO_SEC);

        public Radium(BaseElement disintegrationTo, double startAmount = 0) : base(disintegrationTo, startAmount)
        {
        }
    }
}
