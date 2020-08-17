using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseKickIndoorMerchantRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5661;

        public HouseKickIndoorMerchantRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public HouseKickIndoorMerchantRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
        }
    }
}