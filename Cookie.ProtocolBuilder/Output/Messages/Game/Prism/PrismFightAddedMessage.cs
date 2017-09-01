namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Types.Game.Prism;
    using Utils.IO;

    public class PrismFightAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6452;
        public override ushort MessageID => ProtocolId;
        public PrismFightersInformation Fight { get; set; }

        public PrismFightAddedMessage(PrismFightersInformation fight)
        {
            Fight = fight;
        }

        public PrismFightAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Fight.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Fight = new PrismFightersInformation();
            Fight.Deserialize(reader);
        }

    }
}
