using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Watchdog.Forms.Util
{

    public class GridAllocationEntry : Grid
    {
        private readonly bool isTotal;
        private readonly AllocationTable allocationTable;
        private readonly IPassObject parent;

        public GridAllocationEntry(IPassObject parent,
                                   object dataContext, 
                                   AllocationTable allocationTable, 
                                   bool isTotal = false, 
                                   bool lastRow = false, 
                                   bool lastCol = false) : base()
        {
            this.parent = parent;
            DataContext = dataContext;
            this.allocationTable = allocationTable;
            this.isTotal = isTotal;
            Margin = new Thickness(0);
            RowDefinitions.Add(new RowDefinition());
            CreateTextBox(0, "StrategicMinValue", lastRow);
            CreateTextBox(1, "StrategicOptValue", lastRow);
            CreateTextBox(2, "StrategicMaxValue", lastRow, lastCol);
        }

        private void CreateTextBox(int col, string bindingAttribute, bool lastRow = false, bool lastCol = false)
        {
            Thickness thickness = new Thickness(1, 1, 0, 0);
            if (lastRow)
            {
                thickness.Bottom = 1;
            }
            if (lastCol)
            {
                thickness.Right = 1;
            }
            
            TextBox tb = new TextBox
            {
                HorizontalContentAlignment = HorizontalAlignment.Right,
                VerticalContentAlignment = VerticalAlignment.Center,
                BorderBrush = Brushes.Black,
                BorderThickness = thickness,
            };
            Binding binding = new Binding()
            {
                Path = new PropertyPath(bindingAttribute),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            if (!isTotal)
            {
                tb.TextChanged += CalculateTotals;
            } 
            else
            {
                tb.FontWeight = FontWeights.Bold;
                tb.Background = Brushes.LightBlue;
            }
            tb.SetBinding(TextBox.TextProperty, binding);
            ColumnDefinitions.Add(new ColumnDefinition());
            SetColumn(tb, col);
            SetRow(tb, 0);
            Children.Add(tb);
        }

        private void CalculateTotals(object sender, TextChangedEventArgs e)
        {
            int triggeringColumnGrid = GetColumn(this);
            int triggeringRowGrid = GetRow(this);
            allocationTable.RefreshColumnTotal(triggeringColumnGrid - 1);
            allocationTable.RefreshRowTotal(triggeringRowGrid - 1);
            allocationTable.RefreshGrandTotal();
            IAllocation entryToCache = allocationTable[triggeringColumnGrid - 1, triggeringRowGrid - 1];
            parent.Receive(entryToCache);
        }
    }
}
