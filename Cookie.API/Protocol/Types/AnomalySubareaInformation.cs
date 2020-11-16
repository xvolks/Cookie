using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AnomalySubareaInformation : NetworkType
    {
        public const ushort ProtocolId = 565;

        public override ushort TypeID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public short RewardRate { get; set; }
        public bool HasAnomaly { get; set; }
        public ulong AnomalyClosingTime { get; set; }
        public AnomalySubareaInformation() { }

        public AnomalySubareaInformation( ushort SubAreaId, short RewardRate, bool HasAnomaly, ulong AnomalyClosingTime ){
            this.SubAreaId = SubAreaId;
            this.RewardRate = RewardRate;
            this.HasAnomaly = HasAnomaly;
            this.AnomalyClosingTime = AnomalyClosingTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarShort(RewardRate);
            writer.WriteBoolean(HasAnomaly);
            writer.WriteVarUhLong(AnomalyClosingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            RewardRate = reader.ReadVarShort();
            HasAnomaly = reader.ReadBoolean();
            AnomalyClosingTime = reader.ReadVarUhLong();
        }
    }
}
