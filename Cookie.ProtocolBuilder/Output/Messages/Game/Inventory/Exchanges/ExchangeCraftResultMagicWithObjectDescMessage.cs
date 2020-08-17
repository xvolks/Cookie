namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
    {
        public new const ushort ProtocolId = 6188;
        public override ushort MessageID => ProtocolId;
        public sbyte MagicPoolStatus { get; set; }

        public ExchangeCraftResultMagicWithObjectDescMessage(sbyte magicPoolStatus)
        {
            MagicPoolStatus = magicPoolStatus;
        }

        public ExchangeCraftResultMagicWithObjectDescMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(MagicPoolStatus);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MagicPoolStatus = reader.ReadSByte();
        }

    }
}
