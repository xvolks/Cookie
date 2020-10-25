using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockPropertiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 5824;
        public override uint MessageID { get { return ProtocolId; } }

        public PaddockInstancesInformations Properties;

        public PaddockPropertiesMessage()
        {
        }

        public PaddockPropertiesMessage(
            PaddockInstancesInformations properties
        )
        {
            Properties = properties;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Properties.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Properties = new PaddockInstancesInformations();
            Properties.Deserialize(reader);
        }
    }
}