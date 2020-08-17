using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectJobAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6014;

        public ObjectJobAddedMessage(byte jobId)
        {
            JobId = jobId;
        }

        public ObjectJobAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte JobId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
        }
    }
}