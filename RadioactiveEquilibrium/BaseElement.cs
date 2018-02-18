using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveEquilibrium
{
    public abstract class BaseElement
    {
        public const ulong YEAR_TO_SEC = 365 * DAY_TO_SEC;

        public const ulong DAY_TO_SEC = 86400;

        public virtual ulong HalfLifeSec { get; }

        public BaseElement DisintegrationTo { get; }

        public double Ammount { get; set; }

        public BaseElement(BaseElement disintegrationTo, double startAmount = 0)
        {
            DisintegrationTo = disintegrationTo;
            Ammount = startAmount;
        }

        public void Update(ulong timeDeltaSec)
        {
            //var disintegrationAmount = Ammount * (0.69 / HalfLifeSec * timeDeltaSec);
            var disintegrationAmount = Ammount - Ammount * Math.Pow(0.5, (double)timeDeltaSec / HalfLifeSec);

            Ammount -= disintegrationAmount;
            if (DisintegrationTo != null)
            {
                DisintegrationTo.Ammount += disintegrationAmount;
            }
        }
    }
}