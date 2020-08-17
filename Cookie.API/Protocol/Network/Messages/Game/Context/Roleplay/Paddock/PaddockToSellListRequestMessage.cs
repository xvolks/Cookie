using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockToSellListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6141;

        public PaddockToSellListRequestMessage(ushort pageIndex)
        {
            PageIndex = pageIndex;
        }

        public PaddockToSellListRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort PageIndex { get; set; }

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