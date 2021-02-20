using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlSettingsCountry.xaml
    /// </summary>
    public partial class UserControlSettingsCountry : UserControlCustom<Country>
    {
        public UserControlSettingsCountry()
        {
            InitializeComponent();
            BindData(DgCountries);
        }
    }
}
