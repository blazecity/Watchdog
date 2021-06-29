using ExShift.Mapping;
using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using Watchdog.Entities;
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

        private void WdRibbonButtonSetupClick(object sender, RibbonControlEventArgs e)
        {
            ExcelObjectMapper.Initialize(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            SetupRuleKinds();
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
    }
}
