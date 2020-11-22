using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BasicAllianceInformations : AbstractSocialGroupInfos
    {
        public new const ushort ProtocolId = 419;

        public override ushort TypeID => ProtocolId;

        public uint AllianceId { get; set; }
        public string AllianceTag { get; set; }
        public BasicAllianceInformations() { }

        public BasicAllianceInformations( uint AllianceId, string AllianceTag ){
            this.AllianceId = AllianceId;
            this.AllianceTag = AllianceTag;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
            AllianceTag = reader.ReadUTF();
        }
    }
}
