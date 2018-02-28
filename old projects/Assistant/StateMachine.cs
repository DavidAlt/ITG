using System.Collections.Generic;

namespace GlacialSystems.ITG
{

    class StateMachine
    {
        // PROPERTIES
        private List<IView> _views;
        public List<IView> Views
        {
            get { return _views; }
        }

        // CONSTRUCTORS
        public StateMachine()
        {
            _views = new List<IView>();
        }
    }
}
