using System.ComponentModel;

namespace DALT.Utility
{
    /// <summary>
    /// A base class for objects of which the properties must be observable, particularly Models and ViewModels
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Event to be raised when a property changes value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property
        /// </summary>
        /// <param name="propertyName">The changed property</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises PropertyChanged for the specified property
        /// Not really sure what this is for though, other than giving a convenient name?
        /// </summary>
        /// <param name="propertyName">Property to update (case-sensitive)</param>
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        #endregion // INotifyPropertyChanged Members

    }

}
