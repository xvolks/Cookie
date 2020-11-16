using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6127;
        public override uint MessageID { get { return ProtocolId; } }

        public List<string> Aliases;
        public List<string> Args;
        public List<string> Descriptions;

        public ConsoleCommandsListMessage()
        {
        }

        public ConsoleCommandsListMessage(
            List<string> aliases,
            List<string> args,
            List<string> descriptions
        )
        {
            Aliases = aliases;
            Args = args;
            Descriptions = descriptions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Aliases.Count());
            foreach (var current in Aliases)
            {
                writer.WriteUTF(current);
            }
            writer.WriteShort((short)Args.Count());
            foreach (var current in Args)
            {
                writer.WriteUTF(current);
            }
            writer.WriteShort((short)Descriptions.Count());
            foreach (var current in Descriptions)
            {
                writer.WriteUTF(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAliases = reader.ReadShort();
            Aliases = new List<string>();
            for (short i = 0; i < countAliases; i++)
            {
                Aliases.Add(reader.ReadUTF());
            }
            var countArgs = reader.ReadShort();
            Args = new List<string>();
            for (short i = 0; i < countArgs; i++)
            {
                Args.Add(reader.ReadUTF());
            }
            var countDescriptions = reader.ReadShort();
            Descriptions = new List<string>();
            for (short i = 0; i < countDescriptions; i++)
            {
                Descriptions.Add(reader.ReadUTF());
            }
        }
    }
}