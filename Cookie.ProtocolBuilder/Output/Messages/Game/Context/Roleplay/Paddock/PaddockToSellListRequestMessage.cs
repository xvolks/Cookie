namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    using Utils.IO;

    public class PaddockToSellListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6141;
        public override ushort MessageID => ProtocolId;
        public ushort PageIndex { get; set; }

        public PaddockToSellListRequestMessage(ushort pageIndex)
        {
            PageIndex = pageIndex;
        }

        public PaddockToSellListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
        }

    }
}
