using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class RoomAvailableUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6630;

        public RoomAvailableUpdateMessage(byte nbRoom)
        {
            NbRoom = nbRoom;
        }

        public RoomAvailableUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte NbRoom { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NbRoom);
        }

        public override void Deserialize(IDataReader reader)
        {
            NbRoom = reader.ReadByte();
        }
    }
}