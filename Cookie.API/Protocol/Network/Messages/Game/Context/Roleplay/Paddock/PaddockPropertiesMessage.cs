namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    using Types.Game.Paddock;
    using Utils.IO;

    public class PaddockPropertiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5824;
        public override ushort MessageID => ProtocolId;
        public PaddockInstancesInformations Properties { get; set; }

        public PaddockPropertiesMessage(PaddockInstancesInformations properties)
        {
            Properties = properties;
        }

        public PaddockPropertiesMessage() { }

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
