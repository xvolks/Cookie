using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class OrnamentGainedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6368;
        public override uint MessageID { get { return ProtocolId; } }

        public short OrnamentId = 0;

        public OrnamentGainedMessage()
        {
        }

        public OrnamentGainedMessage(
            short ornamentId
        )
        {
            OrnamentId = ornamentId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(OrnamentId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            OrnamentId = reader.ReadShort();
        }
    }
}