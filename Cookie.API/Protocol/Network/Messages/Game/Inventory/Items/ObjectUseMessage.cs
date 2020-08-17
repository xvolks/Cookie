using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3019;

        public ObjectUseMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectUseMessage()
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