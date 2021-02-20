using Watchdog.Entities;
using Watchdog.Forms.Util;
using System.Collections.Generic;
using ExShift.Mapping;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlAllowListAssets.xaml
    /// </summary>
    public partial class UserControlAllowListAssets : UserControlCustom<Asset>, IEmbeddedRuleUserControl
    {
        public UserControlAllowListAssets()
        {
            InitializeComponent();
            BindData(DgAssets);
        }

        public bool EditMode { get; set; }
        public Rule PassedRule { get; set; }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            AllowList<Asset> allowList = new AllowList<Asset>
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                Allowed = new List<Asset>(observableCollection)
            };
            ExcelObjectMapper.Persist(allowList);
            return allowList;
        }
    }
}
