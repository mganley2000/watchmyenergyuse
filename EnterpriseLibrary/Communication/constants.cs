using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Energy.Communication
{
    /// <summary>
    /// Constants used for the wireless device communications and processing
    /// </summary>
    public class constants
    {
        public const int MAINSVPP = 170 * 2;        // +-170V is what 120Vrms ends up being (= 120*2sqrt(2))
        public const int VREF = 492;                // approx ((2.4v * (10Ko/14.7Ko)) / 3
        public const double CURRENTNORM = 15.5;     // conversion to amperes from ADC
    }
}
