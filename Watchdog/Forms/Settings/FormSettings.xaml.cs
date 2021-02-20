using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für FormSettings.xaml
    /// </summary>
    public partial class FormSettings : Window
    {
        private readonly Dictionary<string, ReturnUserControl> treeViewUserControls;
        private delegate UserControl ReturnUserControl();

        public FormSettings()
        {
            InitializeComponent();
            treeViewUserControls = new Dictionary<string, ReturnUserControl>
            {
                { "trvItemAssetClasses", () => new UserControlSettingsAssetClass()},
                { "trvItemCurrencies", () => new UserControlSettingsCurrency() },
                { "trvItemRatingAgencies", () => new UserControlSettingsRatingAgencies() },
                { "trvItemCountries", () => new UserControlSettingsCountry() }
            };
            ElementHost.EnableModelessKeyboardInterop(GetWindow(this));
        }

        private void SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = sender as TreeView;
            TreeViewItem treeViewItem = treeView.SelectedItem as TreeViewItem;
            UserControl userControl = treeViewUserControls[treeViewItem.Name].Invoke();
            MainPanel.Children.RemoveAt(1);
            MainPanel.Children.Add(userControl);
        }
    }

    public class MenuItem
    {
        public List<MenuItem> Items { get; set; }
        public string Title { get; set; }

        public MenuItem()
        {
            Items = new List<MenuItem>();
        }
    }
}
