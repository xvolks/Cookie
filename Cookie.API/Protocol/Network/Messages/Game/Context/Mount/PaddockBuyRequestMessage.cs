namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class PaddockBuyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5951;
        public override ushort MessageID => ProtocolId;
        public ulong ProposedPrice { get; set; }

        public PaddockBuyRequestMessage(ulong proposedPrice)
        {
            ProposedPrice = proposedPrice;
        }

        public PaddockBuyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ProposedPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            ProposedPrice = reader.ReadVarUhLong();
        }

    }
}
