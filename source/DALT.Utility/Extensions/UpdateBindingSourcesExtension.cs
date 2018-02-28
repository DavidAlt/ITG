using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DALT.Utility.Extensions
{
    // Credit: Taken from sample project at http://www.hardcodet.net/2009/03/moving-data-grid-rows-using-drag-and-drop

    /// <summary>
    /// Recursively updates the sources of all bound properties on a given DependencyObject and its children.
    /// </summary>
    public static class UpdateBindingSourcesExtension
    {

        /// <summary>
        /// Recursively processes a given dependency object and all its
        /// children, and updates sources of all objects that use a
        /// binding expression on a given property.
        /// </summary>
        /// <param name="obj">The dependency object that marks a starting
        /// point. This could be a dialog window or a panel control that
        /// hosts bound controls.</param>
        /// <param name="properties">The properties to be updated if
        /// <paramref name="obj"/> or one of its childs provide it along
        /// with a binding expression.</param>
        public static void UpdateBindingSources(this DependencyObject obj,
                                  params DependencyProperty[] properties)
        {
            Console.WriteLine("UpdateBindingSources: ");
            Console.WriteLine("\tDependencyObject: {0}", obj.ToString());
            Console.WriteLine("\tDependencyProperty[0]: {0}", properties[0].ToString());

            foreach (DependencyProperty depProperty in properties)
            {
                //check whether the submitted object provides a bound property
                //that matches the property parameters
                BindingExpression be = BindingOperations.GetBindingExpression(obj, depProperty);
                if (be != null) be.UpdateSource();
                
            }

            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                //process child items recursively
                DependencyObject childObject = VisualTreeHelper.GetChild(obj, i);
                UpdateBindingSources(childObject, properties);
            }
        }

    }
}
