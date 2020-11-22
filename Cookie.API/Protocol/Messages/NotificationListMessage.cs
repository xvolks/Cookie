using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NotificationListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6087;

        public override ushort MessageID => ProtocolId;

        public List<int> Flags { get; set; }
        public NotificationListMessage() { }

        public NotificationListMessage( List<int> Flags ){
            this.Flags = Flags;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Flags.Count);
			foreach (var x in Flags)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FlagsCount = reader.ReadShort();
            Flags = new List<int>();
            for (var i = 0; i < FlagsCount; i++)
            {
                Flags.Add(reader.ReadVarInt());
            }
        }
    }
}
