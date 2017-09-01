using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseGenericItemAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5947;

        public ExchangeBidHouseGenericItemAddedMessage(ushort objGenericId)
        {
            ObjGenericId = objGenericId;
        }

        public ExchangeBidHouseGenericItemAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjGenericId = reader.ReadVarUhShort();
        }
    }
}