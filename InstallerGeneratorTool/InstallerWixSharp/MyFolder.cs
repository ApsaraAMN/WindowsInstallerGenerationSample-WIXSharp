using System.Collections.Generic;

namespace InstallerWixSharp
{
    public class MyFolder
    {
        public bool HasSubFolder { get; set; }

        public string FolderName { get; set; }

        public string FolderPath { get; set; }

        public IList<string> Files { get; set; }

        public IList<MyFolder> Folders { get; set; }
    }
}
