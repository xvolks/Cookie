using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cookie.Gamedata.D2p
{
    internal sealed class D2pFileManager
    {
        // Methods
        internal D2pFileManager(string Path)
        {
            string File = null;
            foreach (string File_loopVariable in Directory.GetFiles(Path))
            {
                File = File_loopVariable;
                FileInfo info = new FileInfo(File);
                if ((info.Extension.ToUpper() == ".D2P"))
                {
                    ListD2pFileDlm.Add(new D2PFileDlm(File));
                }
            }
        }

        internal byte[] GetMapBytes(string name)
        {
            D2PFileDlm dlm = ListD2pFileDlm.FirstOrDefault(f => f.ExistsDlm(name));
            return dlm?.ReadFile(name);
        }

        // Fields
        private List<D2PFileDlm> ListD2pFileDlm = new List<D2PFileDlm>();
    }
}
