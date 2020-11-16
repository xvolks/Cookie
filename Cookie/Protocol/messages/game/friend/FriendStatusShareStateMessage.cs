using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendStatusShareStateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6823;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Share = false;

        public FriendStatusShareStateMessage()
        {
        }

        public FriendStatusShareStateMessage(
            bool share
        )
        {
            Share = share;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Share);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Share = reader.ReadBoolean();
        }
    }
}