namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class ChangeHavenBagRoomRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6638;
        public override ushort MessageID => ProtocolId;
        public byte RoomId { get; set; }

        public ChangeHavenBagRoomRequestMessage(byte roomId)
        {
            RoomId = roomId;
        }

        public ChangeHavenBagRoomRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RoomId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RoomId = reader.ReadByte();
        }

    }
}
