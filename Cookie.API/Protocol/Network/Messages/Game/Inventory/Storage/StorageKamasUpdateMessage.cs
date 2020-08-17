namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    using Utils.IO;

    public class StorageKamasUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5645;
        public override ushort MessageID => ProtocolId;
        public ulong KamasTotal { get; set; }

        public StorageKamasUpdateMessage(ulong kamasTotal)
        {
            KamasTotal = kamasTotal;
        }

        public StorageKamasUpdateMessage() { }

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
