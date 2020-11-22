using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PrismInformation : NetworkType
    {
        public const short ProtocolId = 428;
        public override short TypeId { get { return ProtocolId; } }

        public byte TypeId_ = 0;
        public byte State = 1;
        public int NextVulnerabilityDate = 0;
        public int PlacementDate = 0;
        public int RewardTokenCount = 0;

        public PrismInformation()
        {
        }

        public PrismInformation(
            byte typeId_,
            byte state,
            int nextVulnerabilityDate,
            int placementDate,
            int rewardTokenCount
        )
        {
            TypeId_ = typeId_;
            State = state;
            NextVulnerabilityDate = nextVulnerabilityDate;
            PlacementDate = placementDate;
            RewardTokenCount = rewardTokenCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(TypeId_);
            writer.WriteByte(State);
            writer.WriteInt(NextVulnerabilityDate);
            writer.WriteInt(PlacementDate);
            writer.WriteVarInt(RewardTokenCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TypeId_ = reader.ReadByte();
            State = reader.ReadByte();
            NextVulnerabilityDate = reader.ReadInt();
            PlacementDate = reader.ReadInt();
            RewardTokenCount = reader.ReadVarInt();
        }
    }
}