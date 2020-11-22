using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockPropertiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5824;

        public override ushort MessageID => ProtocolId;

        public PaddockInstancesInformations Properties { get; set; }
        public PaddockPropertiesMessage() { }

        public PaddockPropertiesMessage( PaddockInstancesInformations Properties ){
            this.Properties = Properties;
        }

        public override void Serialize(IDataWriter writer)
        {
            Properties.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Properties = new PaddockInstancesInformations();
            Properties.Deserialize(reader);
        }
    }
}
