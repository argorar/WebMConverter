using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMConverter.Objects
{
    class SpeedPoint
    {
        public double Time { get; set; }
        public double Speed { get; set; }

        public SpeedPoint(double time, double speed)
        {
            Time = time;
            Speed = speed;
        }
    }
}
