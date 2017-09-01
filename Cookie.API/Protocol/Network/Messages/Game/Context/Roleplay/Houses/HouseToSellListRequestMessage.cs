using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6139;

        public HouseToSellListRequestMessage(ushort pageIndex)
        {
            PageIndex = pageIndex;
        }

        public HouseToSellListRequestMessage()
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