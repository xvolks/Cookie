namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using Utils.IO;

    public class GameEntityDispositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5693;
        public override ushort MessageID => ProtocolId;
        public IdentifiedEntityDispositionInformations Disposition { get; set; }

        public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
        {
            Disposition = disposition;
        }

        public GameEntityDispositionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Disposition = new IdentifiedEntityDispositionInformations();
            Disposition.Deserialize(reader);
        }

    }
}
