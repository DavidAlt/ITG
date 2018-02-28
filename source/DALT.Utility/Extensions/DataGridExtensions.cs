using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;              // DataGrid
using System.Windows.Controls.Primitives;   // DataGridCellsPresenter
using System.Windows.Data;                  // Binding
using System.Windows.Media;                 // VisualTreeHelper
using System.ComponentModel;                // PropertyDescriptorCollection, TypeDescriptor

namespace DALT.Utility.Extensions
{
    public static class DataGridExtensions
    {

        #region CELL Extension Methods

        // Get the cell using a row and the column index
        public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = TreeHelper.GetVisualChild<DataGridCellsPresenter>(row);

                if (presenter == null)
                {
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = TreeHelper.GetVisualChild<DataGridCellsPresenter>(row);
                }

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }


        // Get the cell using row and column indices
        public static DataGridCell GetCell(this DataGrid grid, int row, int column)
        {
            DataGridRow rowContainer = grid.GetRow(row);
            return grid.GetCell(rowContainer, column);
        }


        /// <summary>
        /// Get the cell of the datagrid.
        /// </summary>
        /// <param name="dataGrid">The data grid in question</param>
        /// <param name="cellInfo">The cell information for a row of that datagrid</param>
        /// <param name="cellIndex">The row index of the cell to find. </param>
        /// <returns>The cell or null</returns>
        public static DataGridCell TryToFindGridCell(this DataGrid dataGrid, DataGridCellInfo cellInfo, int cellIndex = -1)
        {
            DataGridRow row;
            DataGridCell result = null;

            if (dataGrid != null && cellInfo != null)
            {
                if (cellIndex < 0)
                    row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(cellInfo.Item);
                else
                    row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(cellIndex);

                if (row != null)
                {
                    int columnIndex = dataGrid.Columns.IndexOf(cellInfo.Column);

                    if (columnIndex > -1)
                    {
                        DataGridCellsPresenter presenter = TreeHelper.GetVisualChild<DataGridCellsPresenter>(row);

                        if (presenter != null)
                            result = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
                        else
                            result = null;
                    }
                }
            }
            return result;
        }


        // Retrieve a cell's data-bound value
        public static object GetBoundValue(this DataGridCell cell)
        {
            // Get the cell's column
            DataGridBoundColumn col = cell.Column as DataGridBoundColumn;

            // Get the name of the property bound to the column
            Binding binding = col.Binding as Binding;
            string boundPropertyName = binding.Path.Path;

            // Get the cell's row
            var parent = VisualTreeHelper.GetParent(cell);
            while (parent != null && parent.GetType() != typeof(DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            DataGridRow row = parent as DataGridRow;
            
            // Get the object in the DataGridRow
            object data = row.Item;

            // Extract the property's value
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            PropertyDescriptor property = properties[boundPropertyName];
            object value = property.GetValue(data);

            return value;
        }

        #endregion


        #region ROW Extension Methods
        
        // only works if a row is selected, obviously - no error checking?!
        public static DataGridRow GetSelectedRow(this DataGrid grid)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        }


        public static DataGridRow GetRow(this DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // May be virtualized, bring into view and try again.
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        #endregion

        
    }
}
