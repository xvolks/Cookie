using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendAddFailureMessage : NetworkMessage
    {
        public const uint ProtocolId = 5600;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;

        public FriendAddFailureMessage()
        {
        }

        public FriendAddFailureMessage(
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