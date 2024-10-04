using System;
using WixSharp;

namespace InstallerWixSharp
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public string OutFileName { get; set; }
        public Guid GUID { get; set; }
        public Version Version { get; set; }
        public InstallScope InstallScope { get; set; }
        public ProductInfo ControlPanelInfo { get; set; }
        public string IconFile { get; set; }
        public string ShortCutExeName { get; set; }
        public Platform Platform { get; set; }
        public string LicenseFile { get; set; }
        public WUI UI { get; set; }
        public string TargetPath { get; set; }
        public WixOutType WixOutType { get; set; }
        public string OutDir { get; set; }
        public string SourcePath { get; set; }
        public string ProductIconPath { get; set; }
    }

    public enum WixOutType
    {
        Msi,
        MSM,
        WXS,
        Bundle
    }
}
