using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class OrnamentSelectedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6369;
        public override uint MessageID { get { return ProtocolId; } }

        public short OrnamentId = 0;

        public OrnamentSelectedMessage()
        {
        }

        public OrnamentSelectedMessage(
            short ornamentId
        )
        {
            OrnamentId = ornamentId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(OrnamentId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            OrnamentId = reader.ReadVarShort();
        }
    }
}