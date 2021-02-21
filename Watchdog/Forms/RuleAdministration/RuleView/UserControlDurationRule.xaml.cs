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
        private DurationRule passedRule;

        public UserControlDurationRule()
        {
            InitializeComponent();
            BindData(DgDurationRuleEntries, false);
            currencyColumn.ItemsSource = new ObservableCollection<Currency>(ExcelObjectMapper.GetAllObjects<Currency>());
        }

        public bool EditMode { get; set; }
        public Rule PassedRule
        {
            get
            {
                return passedRule;
            }
            set
            {
                passedRule = value as DurationRule;
                foreach (DurationRuleEntry entry in passedRule.DurationRuleEntries)
                {
                    observableCollection.Add(entry);
                }
            }
        }

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

        public Rule SubmitEdit()
        {
            if (EditMode)
            {
                passedRule.DurationRuleEntries = new List<DurationRuleEntry>(observableCollection);
                ExcelObjectMapper.Update(PassedRule as DurationRule);
            }
            return PassedRule;
        }
    }
}
