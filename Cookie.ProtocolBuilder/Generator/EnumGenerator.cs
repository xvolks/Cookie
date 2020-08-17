using System.IO;
using System.Text;
using Cookie.ProtocolBuilder.Protocol;

namespace Cookie.ProtocolBuilder.Generator
{
    public class EnumGenerator
    {
        public ProtocolEnum EnumParsed { get; set; }
        public string EnumContent => Writer.ToString();
        public string EnumPath { get; set; }

        private StringBuilder Writer { get; set; }

        public void WriteFile(ProtocolEnum protocolEnum)
        {
            EnumParsed = protocolEnum;
            Writer = new StringBuilder();
            EnumPath = $@"{Directory.GetCurrentDirectory()}\Output\Enums\{EnumParsed.Name}.cs";
            CreateRepositories();
            CreateFile();
            GenerateClass();
        }

        public void CreateRepositories()
        {
            const string path = @"Output\Enums";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateFile()
        {
            if (!File.Exists(EnumPath))
                File.CreateText(EnumPath).Close();
        }

        private void GenerateClass()
        {
            WriteNamespace();
            WriteEnum();
            WriteProperties();
            WriteEndClass();

            if (string.IsNullOrEmpty(EnumContent) || !File.Exists(EnumPath)) return;
            File.WriteAllText(EnumPath, EnumContent, Encoding.UTF8);
        }

        private void WriteNamespace()
        {
            Writer.AppendLine("namespace Cookie.API.Protocol.Enums");
            Writer.AppendLine("{");
        }

        private void WriteEnum()
        {
            Writer.AppendLine($"    public enum {EnumParsed.Name}");
            Writer.AppendLine("    {");
        }

        private void WriteProperties()
        {
            for (var i = 0; i < EnumParsed.Items.Length; i++)
            {
                var item = EnumParsed.Items[i];
                Writer.AppendLine(i != EnumParsed.Items.Length - 1
                    ? $"        {item.Name} = {item.Value},"
                    : $"        {item.Name} = {item.Value}");
            }
        }

        private void WriteEndClass()
        {
            Writer.AppendLine("    }");
            Writer.AppendLine("}");
        }
    }
}