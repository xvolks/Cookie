using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.IO
{
    public class DirectoryInformations
    {
        public List<string> Files;

        public DirectoryInformations(string directory, string extension = "*")
        {
            Files = listAllFiles(new List<string>(), directory, extension, true);
        }

        public DirectoryInformations()
        {

        }

        private List<string> listAllFiles(List<string> allFiles, string path, string ext, bool scanDirOk)
        {
            string[] listFilesCurrDir = Directory.GetFiles(path, string.Format("*.{0}", ext));
            foreach (string rowFile in listFilesCurrDir)
            {
                if (allFiles.Contains(rowFile) == false)
                {
                    allFiles.Add(rowFile);
                }
            }
            listFilesCurrDir = null;
            if (scanDirOk)
            {
                string[] listDirCurrDir = Directory.GetDirectories(path);
                if (listDirCurrDir.Length != 0)
                {
                    foreach (string rowDir in listDirCurrDir)
                    {
                        listAllFiles(allFiles, rowDir, ext, scanDirOk);
                    }
                }
                listDirCurrDir = null;
            }
            return allFiles;
        }

    }
}
