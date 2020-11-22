using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BasicNamedAllianceInformations : BasicAllianceInformations
    {
        public new const ushort ProtocolId = 418;

        public override ushort TypeID => ProtocolId;

        public string AllianceName { get; set; }
        public BasicNamedAllianceInformations() { }

        public BasicNamedAllianceInformations( string AllianceName ){
            this.AllianceName = AllianceName;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(AllianceName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceName = reader.ReadUTF();
        }
    }
}
