namespace Cookie.API.Protocol.Network.Messages.Game.Inventory
{
    using Utils.IO;

    public class KamasUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5537;
        public override ushort MessageID => ProtocolId;
        public ulong KamasTotal { get; set; }

        public KamasUpdateMessage(ulong kamasTotal)
        {
            KamasTotal = kamasTotal;
        }

        public KamasUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KamasTotal);
        }

        public override void Deserialize(IDataReader reader)
        {
            KamasTotal = reader.ReadVarUhLong();
        }

    }
}
