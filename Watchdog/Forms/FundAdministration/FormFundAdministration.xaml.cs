using ExShift.Mapping;
using System.Collections.Generic;
using System.Windows;
using Watchdog.Entities;

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
