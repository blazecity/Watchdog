using System.Windows;
using Watchdog.Entities;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Interaktionslogik für FormFundAdministration.xaml
    /// </summary>
    public partial class FormFundAllocation : Window
    {
        public FormFundAllocation(Fund fund)
        {
            InitializeComponent();
            MainPanel.Children.Add(new UserControlFundAllocation(fund));
        }
    }
}
