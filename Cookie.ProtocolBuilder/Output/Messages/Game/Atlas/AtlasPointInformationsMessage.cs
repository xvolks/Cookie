namespace Cookie.API.Protocol.Network.Messages.Game.Atlas
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class AtlasPointInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5956;
        public override ushort MessageID => ProtocolId;
        public AtlasPointsInformations Type { get; set; }

        public AtlasPointInformationsMessage(AtlasPointsInformations type)
        {
            Type = type;
        }

        public AtlasPointInformationsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Type.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = new AtlasPointsInformations();
            Type.Deserialize(reader);
        }

    }
}
