namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Types.Game.Paddock;
    using Utils.IO;

    public class GameDataPaddockObjectAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5990;
        public override ushort MessageID => ProtocolId;
        public PaddockItem PaddockItemDescription { get; set; }

        public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            PaddockItemDescription.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockItemDescription = new PaddockItem();
            PaddockItemDescription.Deserialize(reader);
        }

    }
}
