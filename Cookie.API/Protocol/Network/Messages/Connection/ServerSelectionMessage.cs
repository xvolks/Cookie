using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class ServerSelectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 40;

        public ushort ServerId;

        public ServerSelectionMessage()
        {
        }

        public ServerSelectionMessage(ushort serverId)
        {
            ServerId = serverId;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
        }
    }
}