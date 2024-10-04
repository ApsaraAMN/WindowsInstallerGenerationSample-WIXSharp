using System;
using System.Collections.Generic;
using System.IO;
using WixSharp;
using WixSharp.CommonTasks;
using File = WixSharp.File;

namespace InstallerWixSharp
{
    public class WixSharpInstallerHelper
    {
        private  Project _project=new Project();
        private const string WindowsService = "Windows.Service.exe"; // Replace with your windows service exe name
        public Feature Feature1 = new Feature("Feature1Name");// replace with you feature name
        public Feature Feature2 = new Feature("Feature2Name");// replace with you feature name

        private static void ReadDirectoriesRecursively(string path, MyFolder myFolder, string folderFolderPath, bool needFolderPath)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    return;

                }
                var directoryInfo = new DirectoryInfo(path);
                myFolder.FolderName = directoryInfo.Name;
                if (needFolderPath) myFolder.FolderPath = folderFolderPath + "\\" + directoryInfo.Name;
                myFolder.Files = new List<string>();
                foreach (var file in directoryInfo.GetFiles())
                {
                    myFolder.Files.Add(file.FullName);
                }

                // Get all subdirectories
                var subdirectories = Directory.GetDirectories(path);
                if (subdirectories.Length > 0)
                {
                    myFolder.HasSubFolder = true;
                    myFolder.Folders = new List<MyFolder>();
                }
                foreach (var subDirectory in subdirectories)
                {
                    var folder = new MyFolder();
                    myFolder.Folders.Add(folder);
                    ReadDirectoriesRecursively(subDirectory, folder, myFolder.FolderPath, true);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void AddSubFoldersAndFiles(MyFolder myFolderDetails, ICollection<WixEntity> wixList, bool isParent)
        {
            var fileEntities = new List<WixEntity>();
            foreach (var file in myFolderDetails.Files)
            {
                var fileName = Path.GetFileName(file);
                if (fileName == WindowsService)
                    continue;
                var guid = Guid.NewGuid().ToString();
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file).Replace("-", "").Replace(".", "").Replace("_", "").Replace("+", "").Replace(" ", "").Replace("~", "").Replace("(", "").Replace(")", "").Replace("=", "");
                var guidSubstring = guid.Substring(0, guid.Length / 2).Replace("-", "");
                var uniqueId = fileNameWithoutExtension + guidSubstring;
                var winItem = new File(new Id(uniqueId), file);
                if (isParent)
                    wixList.Add(winItem);
                else
                    fileEntities.Add(winItem);
            }
            if (!isParent)
            {
                var dir = new Dir(myFolderDetails.FolderPath.TrimStart('\\'), fileEntities.ToArray());
                wixList.Add(dir);
            }

            if (!myFolderDetails.HasSubFolder)
            {
                return;
            }

            foreach (var item in myFolderDetails.Folders)
            {
                AddSubFoldersAndFiles(item, wixList, false);
            }
        }

        private void AddSubFoldersAndFilesForFeature(MyFolder myFolderDetails, ICollection<WixEntity> wixList, bool isParent, ProductDetails productDetails)
        {
            var fileEntities = new List<WixEntity>();
            foreach (var file in myFolderDetails.Files)
            {
                var fileName = Path.GetFileName(file);
                if (fileName == WindowsService)
                    continue;
                var guid = Guid.NewGuid().ToString();
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file).Replace("-", "").Replace(".", "").Replace("_", "").Replace("+", "").Replace(" ", "").Replace("~", "").Replace("(", "").Replace(")", "").Replace("=", "");
                var guidSubstring = guid.Substring(0, guid.Length / 2).Replace("-", "");
                var uniqueId = fileNameWithoutExtension + guidSubstring;
                File winItem;
                if ((fileName.StartsWith("Feature1Name"))) // Will check if DLL name contains the feature name in it and add only those dll's under the feature. This logic can be revised to use as per your requirement
                {
                    winItem = new File(new Id(uniqueId), Feature1, file);
                }
                else if ((fileName.Contains("Feature2Name")))
                {
                    winItem = new File(new Id(uniqueId), Feature2, file);
                }
                else
                {
                    winItem = new File(new Id(uniqueId), file);
                }
                if (isParent)
                    wixList.Add(winItem);
                else
                    fileEntities.Add(winItem);
            }
            if (!isParent)
            {
                var dir = new Dir(myFolderDetails.FolderPath.TrimStart('\\'), fileEntities.ToArray());
                wixList.Add(dir);
            }

            if (!myFolderDetails.HasSubFolder)
            {
                return;
            }

            foreach (var item in myFolderDetails.Folders)
            {
                AddSubFoldersAndFilesForFeature(item, wixList, false, productDetails);
            }
        }

        public void CreateInstaller(ProductDetails productDetails)
        {
            var wixEntities = new List<WixEntity>();
            _project = new Project
            {
                Name = productDetails.Name,
                OutFileName = productDetails.OutFileName,
                GUID = productDetails.GUID,
                Version = productDetails.Version,
                InstallScope = productDetails.InstallScope,
                ControlPanelInfo = productDetails.ControlPanelInfo,
                Platform = productDetails.Platform,
                LicenceFile = productDetails.LicenseFile,
                UI = productDetails.UI
            };

            //Adding service
            var serviceExe = Path.Combine(productDetails.SourcePath, WindowsService);
            if (System.IO.File.Exists(serviceExe))
            {
                var service = new File(serviceExe)
                {
                    ServiceInstaller = new ServiceInstaller
                    {
                        Name = WindowsService,
                        StartOn = SvcEvent.Install,
                        StopOn = SvcEvent.InstallUninstall_Wait,
                        RemoveOn = SvcEvent.Uninstall_Wait
                    }
                };
                wixEntities.Add(service);
            }

            //short cut
            var shortcutDir = new Dir(@"DesktopFolder",
                new ExeFileShortcut(productDetails.Name, $"[INSTALLDIR]{productDetails.ShortCutExeName}", "")
                {
                    // Set the icon file for the shortcut
                    IconFile = productDetails.ProductIconPath,
                });
            wixEntities.Add(shortcutDir);

            //Adding all files and directories
            var myFolderDetails = new MyFolder();
            ReadDirectoriesRecursively(productDetails.SourcePath, myFolderDetails, "", false);
            AddSubFoldersAndFiles(myFolderDetails, wixEntities, true);

            // AddSubFoldersAndFilesForFeature(myFolderDetails, wixEntities, true, productDetails);

            var installDir = new Dir(productDetails.TargetPath, wixEntities.ToArray());
            _project.AddDir(installDir);

            switch (productDetails.WixOutType)
            {
                case WixOutType.Msi:
                    _project.BuildMsi();
                    break;
                case WixOutType.WXS:
                    _project.BuildWxs();
                    break;
                case WixOutType.MSM:
                    _project.BuildMsm();
                    break;
                case WixOutType.Bundle:
                default:
                    CreateSetup();
                    break;
            }
        }

        private static void CreateSetup()
        {

        }
    }
}
