using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Connection
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(ServerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarUhShort();
        }
    }
}