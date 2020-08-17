namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class GoldAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6030;
        public override ushort MessageID => ProtocolId;
        public GoldItem Gold { get; set; }

        public GoldAddedMessage(GoldItem gold)
        {
            Gold = gold;
        }

        public GoldAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Gold.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Gold = new GoldItem();
            Gold.Deserialize(reader);
        }

    }
}
