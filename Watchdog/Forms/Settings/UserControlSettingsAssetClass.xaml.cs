using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlAssetClasses.xaml
    /// </summary>
    public partial class UserControlSettingsAssetClass : UserControlCustom<AssetClass>
    {
        public UserControlSettingsAssetClass()
        {
            InitializeComponent();
            BindData(DgAssetClasses);
        }
    }
}
