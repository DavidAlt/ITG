using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// SOURCES:
// http://danrigby.com/2012/04/01/inotifypropertychanged-the-net-4-5-way-revisited/
// http://danrigby.com/2012/03/01/inotifypropertychanged-the-net-4-5-way/
// http://stackoverflow.com/questions/1315621/implementing-inotifypropertychanged-does-a-better-way-exist

namespace DALT.Utility
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged implementation

        /// <summary>
        ///     Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        ///     Checks if a property already matches a desired value.  Sets the property and
        ///     notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers that
        ///     support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the
        ///     desired value.
        /// </returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }


        /// <summary>
        ///     Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers
        ///     that support <see cref="CallerMemberNameAttribute" />.
        /// </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Raises PropertyChanged for the specified property
        /// Added for backwards compatibility for objects that inherited from ObservableObject
        /// </summary>
        /// <param name="propertyName">Property to update (case-sensitive)</param>
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        #endregion


        #region Example of use
        /*
        private int myNumber;
        public int MyNumber
        {
            get { return myNumber; }
            set { SetProperty(ref myNumber, value); }
        }
        */
        #endregion

    }

}
