using ExShift.Mapping;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlBanListAssetClasses.xaml
    /// </summary>
    public partial class UserControlBanListAssetClasses : UserControlCustomAllowBanList<AssetClass>
    {
        public UserControlBanListAssetClasses()
        {
            InitializeComponent();
            BindData(DgAssetClasses);
        }

        public override Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
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
    }
}
