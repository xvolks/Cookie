using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class RoomAvailableUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6630;
        public override uint MessageID { get { return ProtocolId; } }

        public byte NbRoom = 0;

        public RoomAvailableUpdateMessage()
        {
        }

        public RoomAvailableUpdateMessage(
            byte nbRoom
        )
        {
            NbRoom = nbRoom;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(NbRoom);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NbRoom = reader.ReadByte();
        }
    }
}