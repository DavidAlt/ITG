using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALT.Utility.Extensions
{
    public static class DoubleExtensions
    {
        public static double RoundToNearestWholeNumber(this double value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static double Constrain(this double value, double min, double max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
            return value;
        }
    }
}