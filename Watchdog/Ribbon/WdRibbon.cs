using Microsoft.Office.Tools.Ribbon;
using Watchdog.Forms.FundAdministration;
using Watchdog.Forms.RuleAdministration.MainView;
using Watchdog.Forms.Settings;
using Watchdog.Forms.Util;

namespace Watchdog.Ribbon
{
    public partial class WdRibbon
    {
        private void WdRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void WdRibbonButtonFundAdminClick(object sender, RibbonControlEventArgs e)
        {
            UIThreadHelper.StartUIThread<FormFundAdministration>();
        }

        private void WdRibbonButtonSettings_Click(object sender, RibbonControlEventArgs e)
        {
            UIThreadHelper.StartUIThread<FormSettings>();
        }

        private void WdRibbonButtonRuleAdmin_Click(object sender, RibbonControlEventArgs e)
        {
            UIThreadHelper.StartUIThread<FormRuleAdministration>();
        }
    }
}
