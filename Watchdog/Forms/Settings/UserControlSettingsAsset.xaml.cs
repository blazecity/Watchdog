using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlSettingsAsset.xaml
    /// </summary>
    public partial class UserControlSettingsAsset : UserControlCustom<Asset>
    {
        public UserControlSettingsAsset()
        {
            InitializeComponent();
            BindData(DgAssets);
        }
    }
}
