using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectSetPositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3021;

        public ObjectSetPositionMessage(uint objectUID, byte position, uint quantity)
        {
            ObjectUID = objectUID;
            Position = position;
            Quantity = quantity;
        }

        public ObjectSetPositionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public byte Position { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteByte(Position);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Position = reader.ReadByte();
            Quantity = reader.ReadVarUhInt();
        }
    }
}