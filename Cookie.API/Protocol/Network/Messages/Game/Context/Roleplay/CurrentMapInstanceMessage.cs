namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class CurrentMapInstanceMessage : CurrentMapMessage
    {
        public new const ushort ProtocolId = 6738;
        public override ushort MessageID => ProtocolId;
        public double InstantiatedMapId { get; set; }

        public CurrentMapInstanceMessage(double instantiatedMapId)
        {
            InstantiatedMapId = instantiatedMapId;
        }

        public CurrentMapInstanceMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(InstantiatedMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            InstantiatedMapId = reader.ReadDouble();
        }

    }
}
