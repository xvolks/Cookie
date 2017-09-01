using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectFeedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6290;

        public ObjectFeedMessage(uint objectUID, uint foodUID, uint foodQuantity)
        {
            ObjectUID = objectUID;
            FoodUID = foodUID;
            FoodQuantity = foodQuantity;
        }

        public ObjectFeedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public uint FoodUID { get; set; }
        public uint FoodQuantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(FoodUID);
            writer.WriteVarUhInt(FoodQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            FoodUID = reader.ReadVarUhInt();
            FoodQuantity = reader.ReadVarUhInt();
        }
    }
}