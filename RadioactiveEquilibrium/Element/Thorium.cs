using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveEquilibrium.Element
{
    public class Thorium : BaseElement
    {
        public override ulong HalfLifeSec => (ulong)(7.538 * Math.Pow(10, 4) * YEAR_TO_SEC);

        public Thorium(BaseElement disintegrationTo, double startAmount = 0) : base(disintegrationTo, startAmount)
        {
        }
    }
}
