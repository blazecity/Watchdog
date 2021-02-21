using Watchdog.Entities;
using Watchdog.Forms.Util;
using ExShift.Mapping;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlAllowListAssets.xaml
    /// </summary>
    public partial class UserControlAllowListAssets : UserControlCustomAllowBanList<Asset>, IEmbeddedRuleUserControl
    {
        private AllowList<Asset> passedRule;

        public UserControlAllowListAssets()
        {
            InitializeComponent();
            BindData(DgAssets);
        }

        public bool EditMode { get; set; }
        public Rule PassedRule { 
            get 
            {
                return passedRule;
            } 
            set
            {
                passedRule = value as AllowList<Asset>;
                foreach (AllowBanListChildViewModel<Asset> viewModelItem in viewModelCollection)
                {
                    if (passedRule.Allowed.Contains(viewModelItem.BoundObject))
                    {
                        viewModelItem.IsChecked = true;
                    }
                }
            }
        }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            AllowList<Asset> allowList = new AllowList<Asset>
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                Allowed = GetCheckedItems()
            };
            ExcelObjectMapper.Persist(allowList);
            return allowList;
        }

        public Rule SubmitEdit()
        {
            if (EditMode)
            {
                passedRule.Allowed = GetCheckedItems();
                ExcelObjectMapper.Update(passedRule);
            }
            return passedRule;
        }
    }
}
