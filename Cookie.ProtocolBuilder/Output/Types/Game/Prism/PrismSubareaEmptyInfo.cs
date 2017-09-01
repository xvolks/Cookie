namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    using Utils.IO;

    public class PrismSubareaEmptyInfo : NetworkType
    {
        public const ushort ProtocolId = 438;
        public override ushort TypeID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public uint AllianceId { get; set; }

        public PrismSubareaEmptyInfo(ushort subAreaId, uint allianceId)
        {
            SubAreaId = subAreaId;
            AllianceId = allianceId;
        }

        public PrismSubareaEmptyInfo() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            AllianceId = reader.ReadVarUhInt();
        }

    }
}
