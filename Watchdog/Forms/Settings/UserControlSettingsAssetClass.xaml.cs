using Watchdog.Entities;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlAssetClasses.xaml
    /// </summary>
    public partial class UserControlSettingsAssetClass : UserControlSettings<AssetClass>
    {
        public UserControlSettingsAssetClass()
        {
            InitializeComponent();
            BindData(DgAssetClasses);
        }
    }
}
