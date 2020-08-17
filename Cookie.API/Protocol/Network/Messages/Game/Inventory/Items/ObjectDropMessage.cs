using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectDropMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3005;

        public ObjectDropMessage(uint objectUID, uint quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectDropMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}