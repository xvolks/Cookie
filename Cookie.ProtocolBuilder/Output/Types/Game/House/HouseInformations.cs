namespace Cookie.API.Protocol.Network.Types.Game.House
{
    using Utils.IO;

    public class HouseInformations : NetworkType
    {
        public const ushort ProtocolId = 111;
        public override ushort TypeID => ProtocolId;
        public uint HouseId { get; set; }
        public ushort ModelId { get; set; }

        public HouseInformations(uint houseId, ushort modelId)
        {
            HouseId = houseId;
            ModelId = modelId;
        }

        public HouseInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteVarUhShort(ModelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            ModelId = reader.ReadVarUhShort();
        }

    }
}
