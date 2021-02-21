using ExShift.Mapping;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlBanListAssetClasses.xaml
    /// </summary>
    public partial class UserControlBanListAssetClasses : UserControlCustomAllowBanList<AssetClass>, IEmbeddedRuleUserControl
    {
        private BanList<AssetClass> passedRule;

        public UserControlBanListAssetClasses()
        {
            InitializeComponent();
            BindData(DgAssetClasses);
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
                passedRule = value as BanList<AssetClass>;
                foreach (AllowBanListChildViewModel<AssetClass> viewModelItem in viewModelCollection)
                {
                    if (passedRule.Banned.Contains(viewModelItem.BoundObject))
                    {
                        viewModelItem.IsChecked = true;
                    }
                }
            }
        }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            BanList<AssetClass> banList = new BanList<AssetClass>
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                Banned = GetCheckedItems()
            };
            ExcelObjectMapper.Persist(banList);
            return banList;
        }

        public Rule SubmitEdit()
        {
            if (EditMode)
            {
                passedRule.Banned = GetCheckedItems();
                ExcelObjectMapper.Update(passedRule);
            }
            return passedRule;
        }
    }
}
