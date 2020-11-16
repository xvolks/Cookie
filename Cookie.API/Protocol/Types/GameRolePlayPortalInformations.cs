using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayPortalInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 467;

        public override ushort TypeID => ProtocolId;

        public PortalInformation Portal { get; set; }
        public GameRolePlayPortalInformations() { }

        public GameRolePlayPortalInformations( PortalInformation Portal ){
            this.Portal = Portal;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Portal.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Portal = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Portal.Deserialize(reader);
        }
    }
}
