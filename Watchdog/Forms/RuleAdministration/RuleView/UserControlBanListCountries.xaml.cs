using Watchdog.Entities;
using Watchdog.Forms.Util;
using ExShift.Mapping;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlBanListCountries.xaml
    /// </summary>
    public partial class UserControlBanListCountries : UserControlCustomAllowBanList<Country>
    {
        public UserControlBanListCountries()
        {
            InitializeComponent();
            BindData(DgCountries);
        }

        public override Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
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
    }
}
