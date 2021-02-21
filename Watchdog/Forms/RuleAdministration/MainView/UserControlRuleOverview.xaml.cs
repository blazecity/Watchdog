using ExShift.Mapping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Watchdog.Entities;
using Watchdog.Forms.RuleAdministration.RuleView;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.MainView
{
    /// <summary>
    /// Interaktionslogik für UserControlRuleOverview.xaml
    /// </summary>
    public partial class UserControlRuleOverview : UserControlCustom<Rule>, IPassObject
    {
        private readonly List<Fund> funds;

        public UserControlRuleOverview()
        {
            InitializeComponent();
            BindData(DgRules, true);
            List<Rule> loadedRules = new List<Rule>();
            loadedRules.AddRange(ExcelObjectMapper.GetAllObjects<Rule>());
            loadedRules.AddRange(ExcelObjectMapper.GetAllObjects<DurationRule>());
            loadedRules.AddRange(ExcelObjectMapper.GetAllObjects<NumericRule>());
            loadedRules.AddRange(ExcelObjectMapper.GetAllObjects<RatingRatioRule>());
            observableCollection = new ObservableCollection<Rule>(loadedRules);
            DgRules.ItemsSource = observableCollection;
            funds = new List<Fund>(ExcelObjectMapper.GetAllObjects<Fund>());
        }

        private void ComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<MultiSelectItem> multiSelectItems = new ObservableCollection<MultiSelectItem>();
            foreach (Fund fund in funds)
            {
                MultiSelectItem multiSelectItem = new MultiSelectItem
                {
                    IsNotSelected = true,
                    IsChecked = false,
                    BoundItem = fund,
                    Display = fund.Name
                };
                multiSelectItems.Add(multiSelectItem);
            }
            ComboBox comboBox = sender as ComboBox;
            comboBox.ItemsSource = multiSelectItems;
        }

        private void TextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Visibility = Visibility.Collapsed;
            GetNeighbour<ComboBox>(tb).Visibility = Visibility.Visible;
        }

        private T GetNeighbour<T>(FrameworkElement element) where T : FrameworkElement
        {
            StackPanel sp = element.Parent as StackPanel;
            if (sp.Children[0] == element)
            {
                return (T) sp.Children[1];
            } 
            return (T) sp.Children[0];
        }

        private void ComboBoxDropDownClosed(object sender, EventArgs e)
        {
            // Display text
            ComboBox comboBox = sender as ComboBox;
            comboBox.Visibility = Visibility.Collapsed;
            TextBlock tb = GetNeighbour<TextBlock>(comboBox);
            tb.Visibility = Visibility.Visible;
            ObservableCollection<MultiSelectItem> itemsSource = comboBox.ItemsSource as ObservableCollection<MultiSelectItem>;
            if (itemsSource == null || itemsSource.Count == 0)
            {
                tb.Text = string.Empty;
                return;
            }
            List<MultiSelectItem> selectedItems = new List<MultiSelectItem>();
            foreach (MultiSelectItem m in itemsSource)
            {
                if (m.IsChecked)
                {
                    selectedItems.Add(m);
                }
            }
            if (selectedItems.Count == 0)
            {
                tb.Text = string.Empty;
                return;
            }
            List<Fund> ruleFundList = new List<Fund>();
            string text = selectedItems[0].Display;
            ruleFundList.Add((Fund)selectedItems[0].BoundItem);
            for (int i = 1; i < selectedItems.Count; i++)
            {
                MultiSelectItem multiSelectItem = selectedItems[i];
                text = string.Concat(text, ", ", multiSelectItem.Display);
                ruleFundList.Add((Fund)multiSelectItem.BoundItem);
            }
            MultiSelectItem textHolder = new MultiSelectItem {IsNotSelected = false, IsChecked = false, Display = text, BoundItem = null };
            itemsSource.Add(textHolder);
            comboBox.SelectedItem = textHolder;
            tb.DataContext = textHolder;
            
            // Set funds to fund list of the selected rule
            Rule rule = DgRules.SelectedItem as Rule;
            rule.FundList = ruleFundList;
            DgRowEditEnding(null, null);
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (tb.DataContext == null)
            {
                tb.DataContext = new MultiSelectItem
                {
                    IsNotSelected = false,
                    IsChecked = false,
                    Display = string.Empty,
                    BoundItem = null
                };
            }
            
        }

        private void ComboBoxDropDownOpened(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            MultiSelectItem msi = GetNeighbour<TextBlock>(cb).DataContext as MultiSelectItem;
            ObservableCollection<MultiSelectItem> itemsSource = cb.ItemsSource as ObservableCollection<MultiSelectItem>;
            itemsSource.Remove(msi);
        }

        private void AddNewRuleClick(object sender, RoutedEventArgs e)
        {
            FormRuleView formRuleView = new FormRuleView(this);
            formRuleView.Show();
        }

        public void Receive(object obj)
        {
            Rule rule = obj as Rule;
            observableCollection.Add(rule);
        }

        private void EditRuleClick(object sender, RoutedEventArgs e)
        {
            Rule selectedRule = DgRules.SelectedItem as Rule;
            FormRuleView formRuleView = new FormRuleView(this, selectedRule);
            formRuleView.Show();
        }
    }
}
