using System.Windows;

namespace Watchdog.Forms.RuleAdministration.MainView
{
    /// <summary>
    /// Interaktionslogik für FormFundAdministration.xaml
    /// </summary>
    public partial class FormRuleAdministration : Window
    {
        public FormRuleAdministration()
        {
            InitializeComponent();
            MainPanel.Children.Add(new UserControlRuleOverview());
        }
    }
}
