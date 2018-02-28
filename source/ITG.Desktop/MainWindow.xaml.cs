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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITG.Desktop.DesignerItems;
using ITG.Desktop.Designer;

using DALT.Utility;

namespace ITG.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM mainWindowVM;

        public MainWindow()
        {
            InitializeComponent();
            mainWindowVM = new MainWindowVM();
            this.DataContext = mainWindowVM;
        }


        #region COMMANDS

        void NewOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            
        }

        void OpenOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void SaveOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void SaveAsOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void CloseOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            Close();
        }

        void CutOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void CutCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        void CopyOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void CopyCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        void PasteOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        void DeleteOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        void SelectAllOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        void HelpOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {

        }

        #endregion


        private void DesignerView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Up && (mainWindowVM.DesignerVM.ActiveTab.SelectedItems.Count > 0))
            {
                System.Console.WriteLine("Up pressed in DesignerView");
                mainWindowVM.MoveSelectedItemsUpCommand.Execute(sender);
                e.Handled = true;
            }

            if (e.Key == Key.Down && (mainWindowVM.DesignerVM.ActiveTab.SelectedItems.Count > 0))
            {
                System.Console.WriteLine("Down pressed in DesignerView");
                mainWindowVM.MoveSelectedItemsDownCommand.Execute(sender);
                e.Handled = true;
            }

            if (e.Key == Key.Left && (mainWindowVM.DesignerVM.ActiveTab.SelectedItems.Count > 0))
            {
                System.Console.WriteLine("Left pressed in DesignerView");
                mainWindowVM.MoveSelectedItemsLeftCommand.Execute(sender);
                e.Handled = true;
            }

            if (e.Key == Key.Right && (mainWindowVM.DesignerVM.ActiveTab.SelectedItems.Count > 0))
            {
                System.Console.WriteLine("Right pressed in DesignerView");
                mainWindowVM.MoveSelectedItemsRightCommand.Execute(sender); 
                e.Handled = true;
            }
        }


        // This synchronizes the selection from DataGrid --> Designer (reverse is handled by databinding)
        private void designerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            foreach (DesignerItemBaseVM i in mainWindowVM.DesignerVM.ActiveTab.Items)
            {
                i.IsSelected = false;
            }
            foreach (DesignerItemBaseVM item in grid.SelectedItems)
            {
                item.IsSelected = true;
            }
        }

        private void designerDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            grid.ColumnWidth = DataGridLength.SizeToCells;
        }


        #region DATAGRID - DRAG AND DROP

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
            DependencyProperty.Register("DraggedItem", typeof(DesignerItemBaseVM), typeof(MainWindow));

        /// <summary>
        /// Gets or sets the DraggedItem property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DesignerItemBaseVM DraggedItem
        {
            get { return (DesignerItemBaseVM)GetValue(DraggedItemProperty); }
            set { SetValue(DraggedItemProperty, value); }
        }

        /// <summary>
        /// Initiates a drag/drop operation.
        /// </summary>
        private void designerDataGrid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsEditing || e.ClickCount > 1) return;

            // Find our starting point
            var row = TreeHelper.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(designerDataGrid));


            // cancel operation if a) doesn't exist or b) is being edited
            if (row == null || row.IsEditing) return;

            // otherwise, continue ...
            IsDragging = true;
            if (row.Item is DesignerItemBaseVM)
                DraggedItem = (DesignerItemBaseVM)row.Item;
            else
                ResetDragDrop();
        }


        /// <summary>
        /// Completes a drag/drop operation.
        /// </summary>
        private void windowGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Do nothing if not dragging an item OR user editing something             
            if (!IsDragging || IsEditing) return;

            // get the DataGridRow that we're dropping on top of
            Point posInDataGrid = e.GetPosition(designerDataGrid);
            var row = TreeHelper.TryFindFromPoint<DataGridRow>(designerDataGrid, posInDataGrid);

            // Only proceed if user dragged to another row
            if (row != null)
            {
                //get the target item
                DesignerItemBaseVM targetItem = (DesignerItemBaseVM)designerDataGrid.SelectedItem;

                if (targetItem == null || !ReferenceEquals(DraggedItem, targetItem))
                {
                    mainWindowVM.DesignerVM.ActiveTab.Items.Remove(DraggedItem); // remove the dragged item

                    // determine whether we want to insert above or below
                    Point posInDataGridRow = e.GetPosition(row);
                    bool towardTop = TreeHelper.PointIsCloserToTopHalf(row, posInDataGridRow);

                    int targetIndex = mainWindowVM.DesignerVM.ActiveTab.Items.IndexOf(targetItem); // inserting above
                    if (!towardTop) targetIndex += 1; // inserting below

                    mainWindowVM.DesignerVM.ActiveTab.Items.Insert(targetIndex, DraggedItem); // re-insert the dropped item
                    designerDataGrid.SelectedItem = DraggedItem; // and select it
                }
            }
            ResetDragDrop();
        }

        /// <summary>
        /// Updates the popup's position in case of a drag/drop operation.
        /// </summary>
        private void windowGrid_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDragging || e.LeftButton != MouseButtonState.Pressed) return;

            if (!DragDropPopup.IsOpen)
            {
                designerDataGrid.IsReadOnly = true; //switch to read-only mode
                DragDropPopup.IsOpen = true; //make sure the popup is visible
            }

            Size popupSize = new Size(DragDropPopup.ActualWidth, DragDropPopup.ActualHeight);
            DragDropPopup.PlacementRectangle = new Rect(e.GetPosition(this), popupSize);

            //make sure the row under the grid is being selected
            Point position = e.GetPosition(designerDataGrid);
            var row = TreeHelper.TryFindFromPoint<DataGridRow>(designerDataGrid, position);
            if (row != null) designerDataGrid.SelectedItem = row.Item;
        }

        /// <summary>
        /// Closes the popup and resets the
        /// grid to read-enabled mode.
        /// </summary>
        private void ResetDragDrop()
        {
            IsDragging = false;
            DragDropPopup.IsOpen = false;
            designerDataGrid.IsReadOnly = false;
            DraggedItem = null;
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