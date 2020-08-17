using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    public class PrismInformation : NetworkType
    {
        public const ushort ProtocolId = 428;

        public PrismInformation(byte typeId, byte state, int nextVulnerabilityDate, int placementDate,
            uint rewardTokenCount)
        {
            TypeId = typeId;
            State = state;
            NextVulnerabilityDate = nextVulnerabilityDate;
            PlacementDate = placementDate;
            RewardTokenCount = rewardTokenCount;
        }

        public PrismInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte TypeId { get; set; }
        public byte State { get; set; }
        public int NextVulnerabilityDate { get; set; }
        public int PlacementDate { get; set; }
        public uint RewardTokenCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TypeId);
            writer.WriteByte(State);
            writer.WriteInt(NextVulnerabilityDate);
            writer.WriteInt(PlacementDate);
            writer.WriteVarUhInt(RewardTokenCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            TypeId = reader.ReadByte();
            State = reader.ReadByte();
            NextVulnerabilityDate = reader.ReadInt();
            PlacementDate = reader.ReadInt();
            RewardTokenCount = reader.ReadVarUhInt();
        }
    }
}