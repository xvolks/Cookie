using System.Diagnostics;
using System.IO;
using System.Linq;
using Cookie.ProtocolBuilder.Builders;
using Cookie.ProtocolBuilder.Builders.Cookie.ProtocolBuilder.Builders;
using Cookie.ProtocolBuilder.Generator;
using Cookie.ProtocolBuilder.Parsers;
using static System.Console;

namespace Cookie.ProtocolBuilder
{
    internal class Program
    {
        internal static string InputPath { get; set; }
        internal static string OutputPath { get; set; }

        internal static void Main()
        {
            Process(out var provider);

            var swMessages = Stopwatch.StartNew();
            var messagesBuilder =
                new ProtocolTypeMessageBuilder(
                    provider.Messages.Select(m => new TypeMessageParser(File.ReadAllLines(m))));
            messagesBuilder.ParseFiles();
            messagesBuilder.GenerateFiles();
            swMessages.Stop();

            var swTypes = Stopwatch.StartNew();
            var typesBuilder =
                new ProtocolTypeMessageBuilder(provider.Types.Select(m => new TypeMessageParser(File.ReadAllLines(m))));
            typesBuilder.ParseFiles();
            typesBuilder.GenerateFiles(true);
            swTypes.Stop();

            var swEnums = Stopwatch.StartNew();
            var enumsBuilder = new ProtocolEnumBuilder(provider.Enums.Select(m => new EnumParser(File.ReadAllText(m))));
            enumsBuilder.ParseFiles();
            enumsBuilder.GenerateFiles();
            swEnums.Stop();

            WriteLine($"> Messages generated in {swMessages.ElapsedMilliseconds}ms");
            WriteLine($"> Types generated in {swTypes.ElapsedMilliseconds}ms");
            WriteLine($"> Enums generated in {swEnums.ElapsedMilliseconds}ms");
            ReadKey();
        }

        internal static void Process(out AsProvider provider)
        {
            InputPath = $@"{Directory.GetCurrentDirectory()}\Input";
            OutputPath = $@"{Directory.GetCurrentDirectory()}\Output";

            if (!Directory.Exists(InputPath))
                Directory.CreateDirectory(InputPath);
            if (!Directory.Exists(OutputPath))
                Directory.CreateDirectory(OutputPath);

            provider = new AsProvider(InputPath);
        }
    }
}