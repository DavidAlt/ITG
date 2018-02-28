using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using ITG.Common;
using DALT.Utility;
using DALT.Utility.Extensions;

namespace ITG.MedcinEditor
{
    /// <summary>
    /// Interaction logic for MedcinEditorWindow.xaml
    /// </summary>
    public partial class MedcinEditorWindow : Window
    {

        #region FIELDS AND PROPERTIES

        private MedcinEditorVM vm;

        /// <summary>
        /// State flag indicating whether datagrid can be edited
        /// </summary>
        public bool IsEditing { get; set; }

        /// <summary>
        /// State flag for drag/drop operations
        /// </summary>
        public bool IsDragging { get; set; }

        /// <summary>
        /// State flag indicating whether user has sorted a datagrid column
        /// </summary>
        public bool IsSorted { get; set; }

        /// <summary>
        /// DraggedItem Dependency Property
        /// </summary>
        public static readonly DependencyProperty DraggedItemProperty =
            DependencyProperty.Register("DraggedItem", typeof(MedcinTerm), typeof(MedcinEditorWindow));

        /// <summary>
        /// Gets or sets the DraggedItem property.  This dependency property 
        /// indicates ....
        /// </summary>
        public MedcinTerm DraggedItem
        {
            get { return (MedcinTerm)GetValue(DraggedItemProperty); }
            set { SetValue(DraggedItemProperty, value); }
        }

        #endregion


        #region CONSTRUCTORS

        public MedcinEditorWindow()
        {
            InitializeComponent();

            vm = new MedcinEditorVM();
            this.DataContext = vm;

            ResetSortCommand = new MyCommand(ExecuteResetSortCommand);
        }

        #endregion


        #region COMMANDS

        void CloseOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            Close(); // this will trigger AreYouSure code in the OnClosing event
        }

        void HelpOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            MessageBox.Show("Not implemented.");
        }

        public MyCommand ResetSortCommand { get; private set; }
        private void ExecuteResetSortCommand(object parameter)
        {
            //Console.WriteLine("ExecuteResetSortCommand");
            ResetSort();
        }



        public MyCommand ClearCurrentCellCommand { get; private set; }
        private void ExecuteClearCurrentCellCommand(object parameter)
        {
            var cell = (DataGridCell)parameter;
            // clear cell contents, but keep it selected and in edit mode
            // ???
            
        }

        #endregion


        #region EVENTS

        // Triggered when a property in MedcinData.Terms.<selecteditem> changes
        private void TermsGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            vm.Dirty = true;
        }

        private void TermsGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            vm.Dirty = true;
        }

        private void TermsGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            //Console.WriteLine("PreparingCellForEdit");
            // Not currently used
        }

        private void TermsGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //Console.WriteLine("BeginningEdit");
            IsEditing = true;
            // In case we are in the middle of a drag/drop operation, cancel it...
            if (IsDragging) ResetDragDrop();
        }

        private void TermsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Console.WriteLine("CellEditEnding: ");
            IsEditing = false;            
        }

        private void TermsGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //Console.WriteLine("RowEditEnding");
            // Maybe do some validation here?
        }

        /// <summary>
        /// Initiates a drag action if the grid is not in edit mode.
        /// </summary>
        private void TermsGrid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //var hit = TermsGrid.InputHitTest(e.GetPosition(TermsGrid));
            //Console.WriteLine(hit.GetType());

            

            // don't start a drag/drop operation if user currently editing something
            // OR is holding modifier keys
            // OR double-clicked
            if (IsEditing || DetectUserInput.IsAnyKeyPressed() || e.ClickCount > 1) return; 

            // Find our starting point
            var row = TreeHelper.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(TermsGrid));
            
            // cancel operation if a) doesn't exist or b) is being edited
            if (row == null || row.IsEditing) return; 

            // otherwise, continue ...
            IsDragging = true;
            if (row.Item is MedcinTerm)
                DraggedItem = (MedcinTerm)row.Item;
            else
                ResetDragDrop();       
        }

        /// <summary>
        /// Updates the popup's position in case of a drag/drop operation.
        /// </summary>
        private void LayoutRoot_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDragging || e.LeftButton != MouseButtonState.Pressed) return;

            if (!DragDropPopup.IsOpen)
            {
                TermsGrid.IsReadOnly = true; //switch to read-only mode
                DragDropPopup.IsOpen = true; //make sure the popup is visible
            }

            Size popupSize = new Size(DragDropPopup.ActualWidth, DragDropPopup.ActualHeight);
            DragDropPopup.PlacementRectangle = new Rect(e.GetPosition(this), popupSize);

            //make sure the row under the grid is being selected
            Point position = e.GetPosition(TermsGrid);
            var row = TreeHelper.TryFindFromPoint<DataGridRow>(TermsGrid, position);
            if (row != null) TermsGrid.SelectedItem = row.Item;
        }

        /// <summary>
        /// Completes a drag/drop operation.
        /// </summary>
        private void LayoutRoot_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Do nothing if not dragging an item OR user editing something             
            if (!IsDragging || IsEditing) return; 

            // get the DataGridRow that we're dropping on top of
            Point posInDataGrid = e.GetPosition(TermsGrid);
            var row = TreeHelper.TryFindFromPoint<DataGridRow>(TermsGrid, posInDataGrid);

            // Only proceed if user dragged to another row
            if (row != null)
            {
                //get the target item
                MedcinTerm targetItem = (MedcinTerm)TermsGrid.SelectedItem;

                if (targetItem == null || !ReferenceEquals(DraggedItem, targetItem))
                {
                    vm.Terms.Remove(DraggedItem); // remove the dragged item

                    // determine whether we want to insert above or below
                    Point posInDataGridRow = e.GetPosition(row);
                    bool towardTop = TreeHelper.PointIsCloserToTopHalf(row, posInDataGridRow);

                    int targetIndex = vm.Terms.IndexOf(targetItem); // inserting above
                    if (!towardTop) targetIndex += 1; // inserting below

                    vm.Terms.Insert(targetIndex, DraggedItem); // re-insert the dropped item
                    TermsGrid.SelectedItem = DraggedItem; // and select it
                }
            }
            ResetDragDrop();
        }

        private void TermsGrid_ColumnReordered(object sender, DataGridColumnEventArgs e)
        {
            IsSorted = true;
        }

        private void TermsGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            IsSorted = true;
        }

        private void me_Closing(object sender, CancelEventArgs e)
        {
            if (vm.Dirty)
            {
                if (MessageBox.Show("Unsaved changes will be lost. Exit anyway?", "Discard changes?",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }

        #endregion


        #region METHODS

        /// <summary>
        /// Closes the popup and resets the
        /// grid to read-enabled mode.
        /// </summary>
        private void ResetDragDrop()
        {
            IsDragging = false;
            DragDropPopup.IsOpen = false;
            TermsGrid.IsReadOnly = false;
            DraggedItem = null;
        }

        /// <summary>
        /// If the user has sorted the rows by clicking on the column headers,
        /// reset it so it visually represents the underlying list.
        /// </summary>
        private void ResetSort()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(TermsGrid.ItemsSource);
            if (view != null && view.SortDescriptions != null)
            {
                view.SortDescriptions.Clear();
                foreach (var column in TermsGrid.Columns)
                {
                    column.SortDirection = null;
                }
            }

            IsSorted = false;
        }


        

        #endregion




    }
}

#region DataGrid - Getting the Value of the Selected Cell
/* 
    var cellInfo = dataGridView.SelectedCells[0];
    var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
*/
#endregion

#region DataGrid Events

/* RowEditEnding Event
 * Has access to the DataGridRow and DataGridColumn
 * Occurs immediately before the action (committed, cancelled, edited)
 * Check EditAction parameter for commit vs cancel action
 * Cancel the event completely by setting e.Cancel to true
 */

/* CellEditEnding Event
 * Has access to the DataGridRow and DataGridColumn
 * Has access to the editing FrameworkElement; lets you set properties on the visual itself before a cell commit or cancel
 * Occurs immediately before the action (committed, cancelled, edited)
 * Check EditAction parameter for commit vs cancel action
 * Cancel the event completely by setting e.Cancel to true
 */

/* BeginningEdit Event
 * Has access to the DataGridRow and DataGridColumn; actions include committed, cancelled, edited
 * Occurs immediately prior to the action
 * Cancel the event completely by setting e.Cancel to true
 */

/* PreparingCellForEdit Event
 * Occurs immediately after cell changes from a non-editing to an editing state
 * Allows you to modify the contents of a cell
 */

/* InitializingNewItem Event
 * Occurs when a new item is added
 * Allows you to set properties on a newly created item (e.g, to set defaults)
 */

/* SourceUpdated
 * Occurs when the value of a source property changes (must implement INotifyPropertyChanged)
 */

#endregion

#region DataGridColumns (and Binding)
/* UpdateSourceTrigger=PropertyChanged
 * Normal behavior is to modify an intermediary object, then update the source property
 * after the cell/row loses focus. This updates the source property as soon as the value
 * in the cell changes, before losing focus.
 */

/* NotifyOnSourceUpdated=True
 * Raises the event SourceUpdated
 */
#endregion