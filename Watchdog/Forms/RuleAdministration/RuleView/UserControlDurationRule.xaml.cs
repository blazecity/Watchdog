using ExShift.Mapping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlDurationRule.xaml
    /// </summary>
    public partial class UserControlDurationRule : UserControlCustom<DurationRuleEntry>, IEmbeddedRuleUserControl
    {
        public UserControlDurationRule()
        {
            InitializeComponent();
            BindData(DgDurationRuleEntries);
            currencyColumn.ItemsSource = new ObservableCollection<Currency>(ExcelObjectMapper.GetAllObjects<Currency>());
        }

        public bool EditMode { get; set; }
        public Rule PassedRule { get; set; }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            foreach (DurationRuleEntry durationRuleEntry in observableCollection)
            {
                durationRuleEntry.Id = Guid.NewGuid().ToString();
            }
            DurationRule newRule = new DurationRule
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                DurationRuleEntries = new List<DurationRuleEntry>(observableCollection)
            };
            base.ButtonSubmitClick(null, null);
            ExcelObjectMapper.Persist(newRule);
            return newRule;
        }
    }
}
