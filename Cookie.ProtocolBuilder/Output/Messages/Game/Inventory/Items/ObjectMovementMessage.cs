namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3010;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public byte Position { get; set; }

        public ObjectMovementMessage(uint objectUID, byte position)
        {
            ObjectUID = objectUID;
            Position = position;
        }

        public ObjectMovementMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteByte(Position);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Position = reader.ReadByte();
        }

    }
}
