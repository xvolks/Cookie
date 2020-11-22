using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6127;

        public override ushort MessageID => ProtocolId;

        public List<string> Aliases { get; set; }
        public List<string> Args { get; set; }
        public List<string> Descriptions { get; set; }
        public ConsoleCommandsListMessage() { }

        public ConsoleCommandsListMessage( List<string> Aliases, List<string> Args, List<string> Descriptions ){
            this.Aliases = Aliases;
            this.Args = Args;
            this.Descriptions = Descriptions;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Aliases.Count);
			foreach (var x in Aliases)
			{
				writer.WriteUTF(x);
			}
			writer.WriteShort((short)Args.Count);
			foreach (var x in Args)
			{
				writer.WriteUTF(x);
			}
			writer.WriteShort((short)Descriptions.Count);
			foreach (var x in Descriptions)
			{
				writer.WriteUTF(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var AliasesCount = reader.ReadShort();
            Aliases = new List<string>();
            for (var i = 0; i < AliasesCount; i++)
            {
                Aliases.Add(reader.ReadUTF());
            }
            var ArgsCount = reader.ReadShort();
            Args = new List<string>();
            for (var i = 0; i < ArgsCount; i++)
            {
                Args.Add(reader.ReadUTF());
            }
            var DescriptionsCount = reader.ReadShort();
            Descriptions = new List<string>();
            for (var i = 0; i < DescriptionsCount; i++)
            {
                Descriptions.Add(reader.ReadUTF());
            }
        }
    }
}
