namespace Watchdog.Forms.Util
{
    public class AllocationTable
    {
        private readonly IAllocation[,] allocationTable;

        public IAllocation this[int col, int row]
        {
            get
            {
                return allocationTable[col, row];
            }
            set
            {
                allocationTable[col, row] = value;
            }
        }

        public int ColumnCount { get; }
        public int RowCount { get; }

        public AllocationTable(int columns, int rows)
        {
            allocationTable = new IAllocation[columns, rows];
            ColumnCount = columns;
            RowCount = rows;
        }

        public void RefreshColumnTotal(int column)
        {
            double minSum = 0;
            double optSum = 0;
            double maxSum = 0;
            for (int row = 0; row < RowCount - 1; row++)
            {
                IAllocation entry = allocationTable[column, row];
                minSum += entry.StrategicMinValue;
                optSum += entry.StrategicOptValue;
                maxSum += entry.StrategicMaxValue;
            }
            IAllocation total = allocationTable[column, RowCount - 1];
            total.StrategicMinValue = minSum;
            total.StrategicOptValue = optSum;
            total.StrategicMaxValue = maxSum;
        }

        public void RefreshRowTotal(int row)
        {
            double minSum = 0;
            double optSum = 0;
            double maxSum = 0;
            for (int column = 0; column < ColumnCount - 1; column++)
            {
                IAllocation entry = allocationTable[column, row];
                minSum += entry.StrategicMinValue;
                optSum += entry.StrategicOptValue;
                maxSum += entry.StrategicMaxValue;
            }
            IAllocation total = allocationTable[ColumnCount - 1, row];
            total.StrategicMinValue = minSum;
            total.StrategicOptValue = optSum;
            total.StrategicMaxValue = maxSum;
        }

        public void RefreshGrandTotal()
        {
            RefreshColumnTotal(ColumnCount - 1);
        }
    }
}
