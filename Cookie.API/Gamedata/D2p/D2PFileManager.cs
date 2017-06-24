using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cookie.API.Gamedata.D2p
{
    internal sealed class D2pFileManager
    {
        // Fields
        private readonly List<D2PFileDlm> ListD2pFileDlm = new List<D2PFileDlm>();

        // Methods
        internal D2pFileManager(string Path)
        {
            string File = null;
            foreach (var File_loopVariable in Directory.GetFiles(Path))
            {
                File = File_loopVariable;
                var info = new FileInfo(File);
                if (info.Extension.ToUpper() == ".D2P")
                    ListD2pFileDlm.Add(new D2PFileDlm(File));
            }
        }

        internal byte[] GetMapBytes(string name)
        {
            var dlm = ListD2pFileDlm.FirstOrDefault(f => f.ExistsDlm(name));
            return dlm?.ReadFile(name);
        }
    }
}