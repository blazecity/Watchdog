using System.Windows;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Interaktionslogik für FormFundAdministration.xaml
    /// </summary>
    public partial class FormFundAdministration : Window
    {
        public FormFundAdministration()
        {
            InitializeComponent();
            MainPanel.Children.Add(new UserControlFundList());
        }
    }
}
