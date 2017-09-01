using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6010;

        public ExchangeObjectRemovedFromBagMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ExchangeObjectRemovedFromBagMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarUhInt();
        }
    }
}