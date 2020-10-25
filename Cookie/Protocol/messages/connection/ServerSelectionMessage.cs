using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerSelectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 40;
        public override uint MessageID { get { return ProtocolId; } }

        public short ServerId = 0;

        public ServerSelectionMessage()
        {
        }

        public ServerSelectionMessage(
            short serverId
        )
        {
            ServerId = serverId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ServerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarShort();
        }
    }
}