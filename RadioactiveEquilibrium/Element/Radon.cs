using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveEquilibrium.Element
{
    public class Radon : BaseElement
    {
        public override ulong HalfLifeSec => (ulong)3.824 * DAY_TO_SEC;

        public Radon(BaseElement disintegrationTo, double startAmount = 0) : base(disintegrationTo, startAmount)
        {
        }
    }
}
