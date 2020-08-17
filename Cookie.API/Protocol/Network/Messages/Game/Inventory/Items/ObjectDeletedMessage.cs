using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectDeletedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3024;

        public ObjectDeletedMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectDeletedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
        }
    }
}