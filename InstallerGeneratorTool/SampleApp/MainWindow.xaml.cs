using System.Windows;
using System.Windows.Forms;
using InstallerWixSharp;
using System;
using WixSharp;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly WixSharpInstallerHelper _wixSharpInstallerHelper = new WixSharpInstallerHelper();
        public MainWindow()
        {
            InitializeComponent();
            BtnCreateInstaller.IsEnabled = false;
            Browse.IsEnabled = false;
        }
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            var folderPath = dialog.SelectedPath;
            Browse.Text = folderPath;
            if (!string.IsNullOrEmpty(folderPath)) BtnCreateInstaller.IsEnabled = true;
        }
        private void BtnCreateInstaller_Click(object sender, RoutedEventArgs e)
        {
            var productDetails = GetProductDetails();
            _wixSharpInstallerHelper.CreateInstaller(productDetails);
        }

        //Replace product details with your Product.
        private ProductDetails GetProductDetails()
        {
            var productDetails = new ProductDetails
            {
                IconFile = @"..\SampleApp\dummy_icon.ico",
                InstallScope = InstallScope.perMachine,
                LicenseFile = @"..\SampleApp\LicenseAgreement.rtf",
                Name = "SampleApp",
                Platform = Platform.x64,
                SourcePath = Browse.Text,
                GUID = new Guid("705815ae23fd4be684f9db3507654605"),
                Version = new Version("1.0"),
                ControlPanelInfo = new ProductInfo()
                {
                    Manufacturer = "Manufacturer_Name",
                    ProductIcon = @"..\SampleApp\dummy_icon.ico"
                },
                OutFileName = "SampleApp",
            };
            productDetails.UI = WUI.WixUI_InstallDir;
            productDetails.ProductIconPath = @"..\SampleApp\dummy_icon.ico";
            productDetails.ShortCutExeName = "CalculatorApp";
            productDetails.TargetPath = $@"%ProgramFiles%\{"Manufacturer_Name"}\{"SampleApp"}";
            return productDetails;
        }
    }
}
