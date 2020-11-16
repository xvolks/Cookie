using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NicknameRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5638;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 99;

        public NicknameRefusedMessage()
        {
        }

        public NicknameRefusedMessage(
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