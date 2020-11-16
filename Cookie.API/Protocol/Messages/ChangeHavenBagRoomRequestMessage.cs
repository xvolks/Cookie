using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChangeHavenBagRoomRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6638;

        public override ushort MessageID => ProtocolId;

        public sbyte RoomId { get; set; }
        public ChangeHavenBagRoomRequestMessage() { }

        public ChangeHavenBagRoomRequestMessage( sbyte RoomId ){
            this.RoomId = RoomId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(RoomId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RoomId = reader.ReadSByte();
        }
    }
}
