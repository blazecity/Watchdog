using ExShift.Mapping;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für FormRuleView.xaml
    /// </summary>
    public partial class FormRuleView : Window
    {
        private IEmbeddedRuleUserControl passedUc;
        private readonly IPassObject passedForm;

        public FormRuleView()
        {
            InitializeComponent();
            ObservableCollection<RuleKind> ruleKinds = new ObservableCollection<RuleKind>(ExcelObjectMapper.GetAllObjects<RuleKind>());
            foreach (RuleKind r in ruleKinds)
            {
                ExcelObjectMapper.Persist(r);
            }
            cbRuleKind.ItemsSource = ruleKinds;
        }

        public FormRuleView(IPassObject passedForm) : this()
        {
            this.passedForm = passedForm;
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainView.Children.Clear();
            RuleKind selectedRuleKind = cbRuleKind.SelectedItem as RuleKind;
            switch (selectedRuleKind.RuleCode)
            {
                case "asset_allocation_boundaries":
                    break;

                case "allow_list_assets":
                    SetNewUserControl(new UserControlAllowListAssets());
                    break;

                case "ban_list_countries":
                    SetNewUserControl(new UserControlBanListCountries());
                    break;

                case "ban_list_asset_classes":
                    SetNewUserControl(new UserControlBanListAssetClasses());
                    break;

                case "max_rating_ratio":
                    SetNewUserControl(new UserControlMaxRatingRatio());
                    break;

                case "duration_rule":
                    SetNewUserControl(new UserControlDurationRule());
                    break;

                default:
                    SetNewUserControl(new UserControlWithOneNumericValue());
                    break;
            }
        }

        private void SetNewUserControl(IEmbeddedRuleUserControl userControl)
        {
            passedUc = userControl;
            MainView.Children.Add(userControl as UserControl);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            RuleKind selectedRuleKind = cbRuleKind.SelectedItem as RuleKind;
            string uniqueId = Guid.NewGuid().ToString();
            if (selectedRuleKind.RuleCode == "asset_allocation_boundaries")
            {
                Rule rule = new Rule { Id = uniqueId, RuleKind = selectedRuleKind, Name = ruleName.Text };
                passedForm.Receive(rule);
                return;
            }

            Rule newRule = passedUc.Submit(uniqueId, selectedRuleKind, ruleName.Text);
            newRule.Id = uniqueId;
            newRule.Name = ruleName.Text;
            newRule.RuleKind = selectedRuleKind;
            passedForm.Receive(newRule);
            Close();
        }
    }
}
