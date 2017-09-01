using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cookie.ProtocolBuilder.Generator
{
    public class AsProvider
    {
        public AsProvider(string inputPath)
        {
            Files = Directory.EnumerateFiles(inputPath, "*.as", SearchOption.AllDirectories).ToList();
            Types = Files.Where(o => File.ReadAllLines(o).First().Contains("com.ankamagames.dofus.network.types"))
                .ToList();
            Messages = Files.Where(o => File.ReadAllLines(o).First().Contains("com.ankamagames.dofus.network.messages"))
                .ToList();
            Enums = Files.Where(o => File.ReadAllLines(o).First().Contains("com.ankamagames.dofus.network.enums"))
                .ToList();
            GameDatas = Files.Where(o => File.ReadAllLines(o).First().Contains("com.ankamagames.dofus.datacenter"))
                .ToList();
        }

        private List<string> Files { get; }

        public List<string> Types { get; }
        public List<string> Messages { get; }
        public List<string> Enums { get; }
        public List<string> GameDatas { get; }
    }
}