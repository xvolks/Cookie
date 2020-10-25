using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredDeleteRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5680;
        public override uint MessageID { get { return ProtocolId; } }

        public int AccountId = 0;
        public bool Session = false;

        public IgnoredDeleteRequestMessage()
        {
        }

        public IgnoredDeleteRequestMessage(
            int accountId,
            bool session
        )
        {
            AccountId = accountId;
            Session = session;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AccountId = reader.ReadInt();
            Session = reader.ReadBoolean();
        }
    }
}