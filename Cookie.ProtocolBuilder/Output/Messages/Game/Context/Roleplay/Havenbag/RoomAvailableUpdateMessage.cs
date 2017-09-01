namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class RoomAvailableUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6630;
        public override ushort MessageID => ProtocolId;
        public byte NbRoom { get; set; }

        public RoomAvailableUpdateMessage(byte nbRoom)
        {
            NbRoom = nbRoom;
        }

        public RoomAvailableUpdateMessage() { }

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
