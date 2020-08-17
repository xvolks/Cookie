using Cookie.API.Protocol.Network.Types.Game.Paddock;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockPropertiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5824;

        public PaddockPropertiesMessage(PaddockInstancesInformations properties)
        {
            Properties = properties;
        }

        public PaddockPropertiesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PaddockInstancesInformations Properties { get; set; }

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