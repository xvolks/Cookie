using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectDeleteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3022;

        public ObjectDeleteMessage(uint objectUID, uint quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectDeleteMessage()
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