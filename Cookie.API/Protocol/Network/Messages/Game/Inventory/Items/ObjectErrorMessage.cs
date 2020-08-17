using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3004;

        public ObjectErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public ObjectErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}