using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Authorized
{
    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6127;

        public ConsoleCommandsListMessage(List<string> aliases, List<string> args, List<string> descriptions)
        {
            Aliases = aliases;
            Args = args;
            Descriptions = descriptions;
        }

        public ConsoleCommandsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<string> Aliases { get; set; }
        public List<string> Args { get; set; }
        public List<string> Descriptions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Aliases.Count);
            for (var aliasesIndex = 0; aliasesIndex < Aliases.Count; aliasesIndex++)
                writer.WriteUTF(Aliases[aliasesIndex]);
            writer.WriteShort((short) Args.Count);
            for (var argsIndex = 0; argsIndex < Args.Count; argsIndex++)
                writer.WriteUTF(Args[argsIndex]);
            writer.WriteShort((short) Descriptions.Count);
            for (var descriptionsIndex = 0; descriptionsIndex < Descriptions.Count; descriptionsIndex++)
                writer.WriteUTF(Descriptions[descriptionsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var aliasesCount = reader.ReadUShort();
            Aliases = new List<string>();
            for (var aliasesIndex = 0; aliasesIndex < aliasesCount; aliasesIndex++)
                Aliases.Add(reader.ReadUTF());
            var argsCount = reader.ReadUShort();
            Args = new List<string>();
            for (var argsIndex = 0; argsIndex < argsCount; argsIndex++)
                Args.Add(reader.ReadUTF());
            var descriptionsCount = reader.ReadUShort();
            Descriptions = new List<string>();
            for (var descriptionsIndex = 0; descriptionsIndex < descriptionsCount; descriptionsIndex++)
                Descriptions.Add(reader.ReadUTF());
        }
    }
}