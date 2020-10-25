using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendDeleteResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5601;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;
        public string Name;

        public FriendDeleteResultMessage()
        {
        }

        public FriendDeleteResultMessage(
            bool success,
            string name
        )
        {
            Success = success;
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Success);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Success = reader.ReadBoolean();
            Name = reader.ReadUTF();
        }
    }
}