using System;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DALT.Utility
{
    // Credit: Taken from sample project at http://www.hardcodet.net/2009/03/moving-data-grid-rows-using-drag-and-drop

    /// <summary>
    /// Common UI related helper methods.
    /// </summary>
    public static class TreeHelper
    {

        #region FINDING PARENTS, TYPES, AND CHILDREN

        /// <summary>
        /// Finds a parent of a given item on the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="child">A direct or indirect child of the
        /// queried item.</param>
        /// <returns>The first parent item that matches the submitted
        /// type parameter. If not matching item can be found, a null
        /// reference is being returned.</returns>
        public static T TryFindParent<T>(DependencyObject child)
          where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = GetParentObject(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                //use recursion to proceed with next level
                return TryFindParent<T>(parentObject);
            }
        }


        /* ***** Here's an alternate version of the same thing *****
        private T GetParent<T>(Type parentType, DependencyObject dependencyObject) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
            if (parent.GetType() == parentType)
                return (T)parent;

            return GetParent<T>(parentType, parent);
        }*/


        /// <summary>
        /// This method is an alternative to WPF's
        /// <see cref="VisualTreeHelper.GetParent"/> method, which also
        /// supports content elements. Do note, that for content element,
        /// this method falls back to the logical tree of the element.
        /// </summary>
        /// <param name="child">The item to be processed.</param>
        /// <returns>The submitted item's parent, if available. Otherwise
        /// null.</returns>
        public static DependencyObject GetParentObject(DependencyObject child)
        {
            if (child == null) return null;
            ContentElement contentElement = child as ContentElement;

            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            //if it's not a ContentElement, rely on VisualTreeHelper
            return VisualTreeHelper.GetParent(child);
        }


        /// <summary>
        /// Tries to locate a given item within the visual tree,
        /// starting with the dependency object at a given position. 
        /// </summary>
        /// <typeparam name="T">The type of the element to be found
        /// on the visual tree of the element at the given location.</typeparam>
        /// <param name="reference">The main element which is used to perform
        /// hit testing.</param>
        /// <param name="point">The position to be evaluated on the origin.</param>
        public static T TryFindFromPoint<T>(UIElement reference, Point point)
          where T : DependencyObject
        {
            DependencyObject element = reference.InputHitTest(point) as DependencyObject;
            if (element == null) return null;
            else if (element is T) return (T)element;
            else return TryFindParent<T>(element);
        }


        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        #endregion


        #region DISPLAYING THE LOGICAL AND VISUAL TREES

        // Print the logical tree to the console
        public static void PrintLogicalTree(int depth, object obj)
        {
            Console.WriteLine(GetLogicalTree(depth, obj));
        }

        // Return the logical tree as a string
        public static string GetLogicalTree(int depth, object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("# LOGICAL TREE FOR: {0}", obj));
            WalkLogicalTree(depth, obj, sb);
            return sb.ToString();

        }

        // Recursive function to walk the logical tree
        private static void WalkLogicalTree(int depth, object obj, StringBuilder sb)
        {
            // Print the object with preceding spaces that represent its depth
            sb.AppendLine(new string(' ', depth) + obj);

            // Sometimes leaf nodes aren't DependencyObjects (like strings)
            if (!(obj is DependencyObject)) return;

            // Recursive call for each logical child
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                WalkLogicalTree(depth + 1, child, sb);
        }


        // Print the visual tree to the console
        public static void PrintVisualTree(int depth, DependencyObject obj)
        {
            Console.WriteLine(GetVisualTree(depth, obj));
        }

        // Return the visual tree as a string
        public static string GetVisualTree(int depth, DependencyObject obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("# VISUAL TREE FOR: {0}", obj));
            WalkVisualTree(depth, obj, sb);
            return sb.ToString();

        }

        // Recursive function to walk the visual tree
        private static void WalkVisualTree(int depth, DependencyObject obj, StringBuilder sb)
        {
            // Print the object with preceding spaces that represent its depth
            sb.AppendLine(new string(' ', depth) + obj);

            // Recursive call for each logical child
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                WalkVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i), sb);
        }

        #endregion


        #region OTHER

        /// <summary>
        /// Determines whether a given set of coordinates occurred in the upper
        /// half of the FrameworkElement
        /// </summary>
        /// <typeparam name="source">The FrameworkElement that was clicked on.</typeparam>
        /// <param name="point">The coordinates used for hit testing.</param>
        public static bool PointIsCloserToTopHalf(FrameworkElement source, Point point)
        {
            bool result = false;

            try
            {
                Rect upperHalf = new Rect(0, 0, source.ActualWidth, (source.ActualHeight / 2));
                if (upperHalf.Contains(point))
                    result = true;
                else
                    result = false;
            }

            catch (NullReferenceException e)
            {
                Console.WriteLine("Operation failed: {0}", e.ToString());
            }

            return result;

        }

        #endregion
    }
}
