using ExShift.Mapping;
using System.Collections.Generic;
using System.Windows;
using Watchdog.Entities;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Interaktionslogik für FormFundAdministration.xaml
    /// </summary>
    public partial class FormFundAdministration : Window
    {
        public FormFundAdministration()
        {
            InitializeComponent();
            List<AssetClass> assetClasses = new List<AssetClass>();
            assetClasses.Add(new AssetClass { ShortName = "Liq", Name = "Liquidität" });
            assetClasses.Add(new AssetClass { ShortName = "Eq", Name = "Aktien" });
            assetClasses.Add(new AssetClass { ShortName = "Obl", Name = "Obligationen" });
            foreach (AssetClass ac in assetClasses)
            {
                ExcelObjectMapper.Persist(ac);
            }

            List<Currency> currencies = new List<Currency>();
            currencies.Add(new Currency { IsoCode = "CHF", Name = "Schweizer Franken" });
            currencies.Add(new Currency { IsoCode = "EUR", Name = "Euro" });
            currencies.Add(new Currency { IsoCode = "USD", Name = "US-Dollar" });

            foreach (Currency c in currencies)
            {
                ExcelObjectMapper.Persist(c);
            }
            MainPanel.Children.Add(new UserControlFundList());
        }
    }
}
