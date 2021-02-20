using ExShift.Mapping;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Interaktionslogik für UserControlFundList.xaml
    /// </summary>
    public partial class UserControlFundList : UserControlCustom<Fund>
    {
        private readonly List<AssetAllocationEntry> entriesToDelete;

        public UserControlFundList()
        {
            InitializeComponent();
            entriesToDelete = new List<AssetAllocationEntry>();
            BindData(DgFunds);
            currencyColumn.ItemsSource = new ObservableCollection<Currency>(ExcelObjectMapper.GetAllObjects<Currency>());
        }

        private void MenuItemChangeAllocationClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Fund selectedFund = DgFunds.SelectedItem as Fund;
            if (selectedFund == null)
            {
                return;
            }
            FormFundAllocation formSettings = new FormFundAllocation(selectedFund);
            formSettings.Show();
        }

        public override void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            if (observableCollection.Count == 0)
            {
                return;
            }
            Fund item = dataGrid.SelectedItem as Fund;
            entriesToDelete.AddRange(Query<AssetAllocationEntry>.Select()
                                                                .Where(string.Concat("Fund = ", "'", item.Isin, "'"))
                                                                .Run());
            
            base.MenuItemDeleteClick(sender, e);
        }

        public override void ButtonSubmitClick(object sender, RoutedEventArgs e)
        {
            foreach (AssetAllocationEntry assetAllocationEntry in entriesToDelete)
            {
                ExcelObjectMapper.Delete(assetAllocationEntry);
            }
            base.ButtonSubmitClick(sender, e);
        }
    }
}
