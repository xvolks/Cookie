using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
    {
        public new const ushort ProtocolId = 444;

        public override ushort TypeID => ProtocolId;

        public BasicAllianceInformations Alliance { get; set; }
        public CharacterMinimalAllianceInformations() { }

        public CharacterMinimalAllianceInformations( BasicAllianceInformations Alliance ){
            this.Alliance = Alliance;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}
