using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
    {
        public new const ushort ProtocolId = 6000;

        public ExchangeCraftResultWithObjectIdMessage(ushort objectGenericId)
        {
            ObjectGenericId = objectGenericId;
        }

        public ExchangeCraftResultWithObjectIdMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjectGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGenericId = reader.ReadVarUhShort();
        }
    }
}