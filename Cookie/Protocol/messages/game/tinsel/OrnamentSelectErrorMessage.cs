using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class OrnamentSelectErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6370;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;

        public OrnamentSelectErrorMessage()
        {
        }

        public OrnamentSelectErrorMessage(
            byte reason
        )
        {
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reason = reader.ReadByte();
        }
    }
}