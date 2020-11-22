using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 161;

        public override ushort TypeID => ProtocolId;

        public PrismInformation Prism { get; set; }
        public GameRolePlayPrismInformations() { }

        public GameRolePlayPrismInformations( PrismInformation Prism ){
            this.Prism = Prism;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Prism = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Prism.Deserialize(reader);
        }
    }
}
