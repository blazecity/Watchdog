using ExShift.Mapping;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Interaktionslogik für UserControlFundAllocation.xaml
    /// </summary>
    public partial class UserControlFundAllocation : UserControl, IPassObject
    {
        private readonly Fund fund;
        private AllocationTable allocationTable;
        private readonly List<AssetAllocationEntry> cache;

        public UserControlFundAllocation(Fund fund)
        {
            InitializeComponent();
            this.fund = fund;
            cache = new List<AssetAllocationEntry>();
            title.Content = string.Concat("Soll-Allokation ", fund.Name);
            SetHeadersAndEntries();
        }

        private List<T> GetHeaderObjects<T>() where T : IPersistable, new()
        {
            List<T> result = ExcelObjectMapper.GetAllObjects<T>().ToList();
            return result;
        }

        private void AddHeader(string bindingAttribute = "", object bindingSource = null, int col = 0, int row = 0, bool lastCol = false, bool lastRow = false)
        {
            if (row == 0)
            {
                AllocationGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            if (col == 0)
            {
                AllocationGrid.RowDefinitions.Add(new RowDefinition());
            }
            Thickness thickness = new Thickness(1, 1, 0, 0);
            if (lastCol)
            {
                thickness.Right = 1;
            }
            if (lastRow)
            {
                thickness.Bottom = 1;
            }
            Label header = new Label
            {
                FontWeight = FontWeights.Bold,
                BorderThickness = thickness,
                BorderBrush = Brushes.Black,
                Background = Brushes.LightBlue
            };
            if (!string.IsNullOrEmpty(bindingAttribute) && bindingSource != null)
            {
                Binding binding = new Binding(bindingAttribute);
                header.DataContext = bindingSource;
                header.SetBinding(ContentProperty, binding);
            }
            if (bindingSource == null)
            {
                header.Content = bindingAttribute;
            }
            Grid.SetColumn(header, col);
            Grid.SetRow(header, row);
            AllocationGrid.Children.Add(header);
        }

        private void AddTotalEntry(int col, int row, bool lastCol = false, bool lastRow = false)
        {
            AllocationTotal allocationTotal = new AllocationTotal();
            allocationTable[col - 1, row - 1] = allocationTotal;
            GridAllocationEntry total = new GridAllocationEntry(this, allocationTotal, allocationTable, true, lastRow, lastCol)
            {
                IsEnabled = false
            };
            Grid.SetColumn(total, col);
            Grid.SetRow(total, row);
            AllocationGrid.Children.Add(total);
        }

        private void SetHeadersAndEntries()
        {
            List<AssetClass> assetClasses = GetHeaderObjects<AssetClass>();
            List<Currency> currencies = GetHeaderObjects<Currency>();
            allocationTable = new AllocationTable(assetClasses.Count + 1, currencies.Count + 1);

            // First cell
            AddHeader();

            // Column headers
            int columnCounter = 1;
            foreach (AssetClass assetClass in assetClasses)
            {
                AddHeader("Name", assetClass, col: columnCounter);
                AddTotalEntry(columnCounter, currencies.Count + 1, lastRow: true);
                columnCounter++;
            }

            // Row headers
            int rowCounter = 1;
            foreach (Currency currency in currencies)
            {
                AddHeader("IsoCode", currency, row: rowCounter);
                AddTotalEntry(assetClasses.Count + 1, rowCounter, lastCol: true);
                rowCounter++;
            }

            // Total headers
            AddHeader("Total", row: currencies.Count + 1, lastRow: true);
            AddHeader("Total", col: assetClasses.Count + 1, lastCol: true);
            AddTotalEntry(assetClasses.Count + 1, currencies.Count + 1, true, true);

            // Asset allocation entries
            string pkFund = AttributeHelper.GetPrimaryKey(fund);

            for (int col = 0; col < assetClasses.Count; col++)
            {
                for (int row = 0; row < currencies.Count; row++)
                {
                    string pkAssetClass = AttributeHelper.GetPrimaryKey(assetClasses[col]);
                    string pkCurrency = AttributeHelper.GetPrimaryKey(currencies[row]);

                    List<AssetAllocationEntry> result = Query<AssetAllocationEntry>.Select()
                                                                                   .Where(string.Concat("Fund = ", "'", pkFund, "'"))
                                                                                   .And(string.Concat("AssetClass = ", "'", pkAssetClass, "'"))
                                                                                   .And(string.Concat("Currency = ", "'", pkCurrency, "'"))
                                                                                   .Run();


                    IAllocation entry;
                    if (result.Count == 0)
                    {
                        AssetAllocationEntry newEntry = new AssetAllocationEntry
                        {
                            Fund = fund,
                            AssetClass = assetClasses[col],
                            Currency = currencies[row],
                            Id = string.Concat(pkFund, pkAssetClass, pkCurrency)
                        };
                        ExcelObjectMapper.Persist(newEntry);
                        entry = newEntry;
                        allocationTable[col, row] = newEntry;
                    }
                    else
                    {
                        entry = result[0];
                        allocationTable[col, row] = result[0];
                    }
                    GridAllocationEntry entryGrid = new GridAllocationEntry(this, entry, allocationTable);
                    Grid.SetColumn(entryGrid, col + 1);
                    Grid.SetRow(entryGrid, row + 1);
                    AllocationGrid.Children.Add(entryGrid);
                }
            }
        }

        private void ButtonSubmitClick(object sender, RoutedEventArgs e)
        {
            foreach (AssetAllocationEntry entry in cache)
            {
                ExcelObjectMapper.Update(entry);
            }
        }

        public void Receive(object obj)
        {
            cache.Add((AssetAllocationEntry)obj);
        }
    }
}
