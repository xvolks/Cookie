using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendJoinRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5605;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;

        public FriendJoinRequestMessage()
        {
        }

        public FriendJoinRequestMessage(
            string name
        )
        {
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
        }
    }
}