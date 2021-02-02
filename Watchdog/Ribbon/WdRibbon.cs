using ExShift.Mapping;
using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;
using Watchdog.Entities;
using Watchdog.Forms.Settings;

namespace Watchdog.Ribbon
{
    public partial class WdRibbon
    {
        private void WdRibbon_Load(object sender, RibbonUIEventArgs e)
        {
#if DEBUG
            ExcelObjectMapper.SetWorkbook(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            ExcelObjectMapper.Initialize();
#endif
        }

        private void WdRibbonButtonFundAdminClick(object sender, RibbonControlEventArgs e)
        {
            
        }

        private void WdRibbonButtonSettings_Click(object sender, RibbonControlEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                FormSettings formSettings = new FormSettings();
                formSettings.Show();
                formSettings.Closed += (sender2, e2) => formSettings.Dispatcher.InvokeShutdown();
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
