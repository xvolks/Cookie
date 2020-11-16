using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendAddRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 4004;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;

        public FriendAddRequestMessage()
        {
        }

        public FriendAddRequestMessage(
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