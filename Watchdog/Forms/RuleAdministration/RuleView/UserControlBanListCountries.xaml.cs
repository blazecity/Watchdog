using Watchdog.Entities;
using Watchdog.Forms.Util;
using ExShift.Mapping;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlBanListCountries.xaml
    /// </summary>
    public partial class UserControlBanListCountries : UserControlCustomAllowBanList<Country>, IEmbeddedRuleUserControl
    {
        private BanList<Country> passedRule;

        public UserControlBanListCountries()
        {
            InitializeComponent();
            BindData(DgCountries);
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
                passedRule = value as BanList<Country>;
                foreach (AllowBanListChildViewModel<Country> viewModelItem in viewModelCollection)
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
            BanList<Country> banList = new BanList<Country>
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
                ExcelObjectMapper.Update(PassedRule as BanList<Country>);
            }
            return passedRule;
        }
    }
}
