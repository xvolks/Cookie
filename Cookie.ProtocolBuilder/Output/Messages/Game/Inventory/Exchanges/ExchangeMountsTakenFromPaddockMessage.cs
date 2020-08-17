namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeMountsTakenFromPaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6554;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public string Ownername { get; set; }

        public ExchangeMountsTakenFromPaddockMessage(string name, short worldX, short worldY, string ownername)
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Ownername = ownername;
        }

        public ExchangeMountsTakenFromPaddockMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Ownername);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Ownername = reader.ReadUTF();
        }

    }
}
