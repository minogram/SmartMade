using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ActiproSoftware.Products;
using ActiproSoftware.Windows.Themes;
using OfficeOpenXml;

namespace EPPlueSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RegisterLicense();
            InitializeActiproThemes();
        }

        #region Actipro
        private static void RegisterLicense()
        {
            // EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Actipro 
            var licensee = "Youth Hitech Co. Ltd.";
            var licenseKey = "WPF211-826CW-G5J7Y-JG4WV-GFCG";
            ActiproLicenseManager.RegisterLicense(licensee, licenseKey);
        }

        private static void InitializeActiproThemes()
        {
            try
            {
                ThemeManager.BeginUpdate();
                ThemeManager.AreNativeThemesEnabled = true;
                ThemeManager.RegisterAutomaticThemes(ThemeNames.Light, ThemeNames.Dark, ThemeNames.HighContrast);
                ThemeManager.CurrentTheme = ThemeNames.Dark;
                //ThemeManager.RegisterAutomaticThemes(ThemeNames.MetroWhite, ThemeNames.MetroDark, ThemeNames.HighContrast);
                //ThemeManager.CurrentTheme = ThemeNames.White;
                //ThemeManager.CurrentTheme = ThemeNames.Dark;
                //ThemeManager.CurrentTheme = ThemeNames.Black; 
            }
            finally
            {
                ThemeManager.EndUpdate();
            }
        }
        #endregion
    }
}
