using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PrismSubareaEmptyInfo : NetworkType
    {
        public const ushort ProtocolId = 438;

        public override ushort TypeID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public uint AllianceId { get; set; }
        public PrismSubareaEmptyInfo() { }

        public PrismSubareaEmptyInfo( ushort SubAreaId, uint AllianceId ){
            this.SubAreaId = SubAreaId;
            this.AllianceId = AllianceId;
        }

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
