using Watchdog.Entities;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlSettingsCurrency.xaml
    /// </summary>
    public partial class UserControlSettingsCurrency : UserControlSettings<Currency>
    {
        public UserControlSettingsCurrency()
        {
            InitializeComponent();
            BindData(DgCurrencies);
        }
    }
}
