using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PrismInformation : NetworkType
    {
        public const ushort ProtocolId = 428;

        public override ushort TypeID => ProtocolId;

        public sbyte TypeId { get; set; }
        public sbyte State { get; set; }
        public int NextVulnerabilityDate { get; set; }
        public int PlacementDate { get; set; }
        public uint RewardTokenCount { get; set; }
        public PrismInformation() { }

        public PrismInformation( sbyte TypeId, sbyte State, int NextVulnerabilityDate, int PlacementDate, uint RewardTokenCount ){
            this.TypeId = TypeId;
            this.State = State;
            this.NextVulnerabilityDate = NextVulnerabilityDate;
            this.PlacementDate = PlacementDate;
            this.RewardTokenCount = RewardTokenCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(TypeId);
            writer.WriteSByte(State);
            writer.WriteInt(NextVulnerabilityDate);
            writer.WriteInt(PlacementDate);
            writer.WriteVarUhInt(RewardTokenCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            TypeId = reader.ReadSByte();
            State = reader.ReadSByte();
            NextVulnerabilityDate = reader.ReadInt();
            PlacementDate = reader.ReadInt();
            RewardTokenCount = reader.ReadVarUhInt();
        }
    }
}
