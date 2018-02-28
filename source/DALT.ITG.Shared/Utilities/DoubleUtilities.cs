using System;

namespace DALT.ITG.Shared.Utilities
{
    public static class DoubleUtilities
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
