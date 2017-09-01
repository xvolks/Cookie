namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    using Utils.IO;

    public class PaddockInformations : NetworkType
    {
        public const ushort ProtocolId = 132;
        public override ushort TypeID => ProtocolId;
        public ushort MaxOutdoorMount { get; set; }
        public ushort MaxItems { get; set; }

        public PaddockInformations(ushort maxOutdoorMount, ushort maxItems)
        {
            MaxOutdoorMount = maxOutdoorMount;
            MaxItems = maxItems;
        }

        public PaddockInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MaxOutdoorMount);
            writer.WriteVarUhShort(MaxItems);
        }

        public override void Deserialize(IDataReader reader)
        {
            MaxOutdoorMount = reader.ReadVarUhShort();
            MaxItems = reader.ReadVarUhShort();
        }

    }
}
