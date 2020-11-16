using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6667;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Error = 0;

        public DareErrorMessage()
        {
        }

        public DareErrorMessage(
            byte error
        )
        {
            Error = error;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Error);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Error = reader.ReadByte();
        }
    }
}