using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Core;
using Watchdog.Ribbon;
using ExShift.Mapping;

namespace Watchdog
{
    public partial class WatchdogAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            if (Globals.WatchdogAddIn.Application.ActiveWorkbook.Name == "Depotbank")
            {
                ExcelObjectMapper.SetWorkbook(Globals.WatchdogAddIn.Application.ActiveWorkbook);
                ExcelObjectMapper.Initialize();
            }
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return Globals.Factory.GetRibbonFactory().CreateRibbonManager(
                new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new WdRibbon() });
        }

        #region Von VSTO generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
