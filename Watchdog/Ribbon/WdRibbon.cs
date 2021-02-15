using Microsoft.Office.Tools.Ribbon;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Watchdog.Forms.FundAdministration;
using Watchdog.Forms.RuleAdministration.MainView;
using Watchdog.Forms.Settings;

namespace Watchdog.Ribbon
{
    public partial class WdRibbon
    {
        private void WdRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void WdRibbonButtonFundAdminClick(object sender, RibbonControlEventArgs e)
        {
            StartUIThread<FormFundAdministration>();
        }

        private void WdRibbonButtonSettings_Click(object sender, RibbonControlEventArgs e)
        {
            StartUIThread<FormSettings>();
        }

        private void WdRibbonButtonRuleAdmin_Click(object sender, RibbonControlEventArgs e)
        {
            StartUIThread<FormRuleAdministration>();
        }

        private void StartUIThread<T>() where T : Window, new()
        {
            Thread thread = new Thread(() =>
            {
                T window = new T();
                window.Show();
                window.Closed += (sender, e) => window.Dispatcher.InvokeShutdown();
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
