using System.Collections.Generic;
using Microsoft.Office.Core;
using Watchdog.Ribbon;
using ExShift.Mapping;
using Watchdog.Entities;

namespace Watchdog
{
    public partial class WatchdogAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
#if DEBUG
            ExcelObjectMapper.Initialize(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            SetupRuleKinds();
#endif
            if (Globals.WatchdogAddIn.Application.ActiveWorkbook.Name == "Depotbank")
            {
                ExcelObjectMapper.Initialize(Globals.WatchdogAddIn.Application.ActiveWorkbook);
                SetupRuleKinds();
            }
        }

        private void SetupRuleKinds()
        {
            if (ExcelObjectMapper.FindTable(typeof(RuleKind).Name) == null)
            {
                List<RuleKind> ruleKinds = new List<RuleKind>
                {
                    new RuleKind { RuleCode = "allow_list_assets", Description = "Ausnahmeregelung Valoren" },
                    new RuleKind { RuleCode = "ban_list_asset_classes", Description = "Nicht-zugelassene Asset-Klassen" },
                    new RuleKind { RuleCode = "ban_list_countries", Description = "Nicht-zugelassene Länder" },
                    new RuleKind { RuleCode = "asset_allocation_boundaries", Description = "Abweichung innerhalb AA-Strategie" },
                    new RuleKind { RuleCode = "min_rating", Description = "Minimale Ratinganforderung" },
                    new RuleKind { RuleCode = "max_diff_asset_classes", Description = "Maximale Abweichung Asset-Klasse" },
                    new RuleKind { RuleCode = "max_diff_currencies", Description = "Maximale Abweichung Währung" },
                    new RuleKind { RuleCode = "max_diff_duration", Description = "Maximale Abweichung Soll-Duration"},
                    new RuleKind { RuleCode = "max_issuer_limit", Description = "Maximaler Emittentenanteil"},
                    new RuleKind { RuleCode = "max_leverage_asset_classes", Description = "Maximaler Leverage Asset-Klassen" },
                    new RuleKind { RuleCode = "max_leverage_currencies", Description = "Maximaler Leverage Währungen" },
                    new RuleKind { RuleCode = "max_rating_ratio", Description = "Maximaler Ratinganteil" },
                    new RuleKind { RuleCode = "duration_rule", Description = "Soll-Durationen"}
                };

                foreach (RuleKind r in ruleKinds)
                {
                    ExcelObjectMapper.Persist(r);
                }
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