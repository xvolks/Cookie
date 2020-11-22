using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChangeHavenBagRoomRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6638;
        public override uint MessageID { get { return ProtocolId; } }

        public byte RoomId = 0;

        public ChangeHavenBagRoomRequestMessage()
        {
        }

        public ChangeHavenBagRoomRequestMessage(
            byte roomId
        )
        {
            RoomId = roomId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(RoomId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RoomId = reader.ReadByte();
        }
    }
}