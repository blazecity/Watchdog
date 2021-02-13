using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlSettingsCurrency.xaml
    /// </summary>
    public partial class UserControlSettingsCurrency : UserControlCustom<Currency>
    {
        public UserControlSettingsCurrency()
        {
            InitializeComponent();
            BindData(DgCurrencies);
        }
    }
}
