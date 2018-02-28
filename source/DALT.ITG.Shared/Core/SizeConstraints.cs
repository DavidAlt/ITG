
namespace DALT.ITG.Shared.Core
{
    public class SizeConstraints
    {

        public SizeConstraints(
            double minimumWidth, double maximumWidth,
            double minimumHeight, double maximumHeight,
            bool enforced = true)
        {
            MinimumWidth = minimumWidth;
            MaximumWidth = maximumWidth;
            MinimumHeight = minimumHeight;
            MaximumHeight = maximumHeight;
            Enforced = enforced;
        }

        
        public double MinimumWidth { get; private set; }
        public double MaximumWidth { get; private set; }
        public double MinimumHeight { get; private set; }
        public double MaximumHeight { get; private set; }

        public bool Enforced { get; set; }

    }
}
