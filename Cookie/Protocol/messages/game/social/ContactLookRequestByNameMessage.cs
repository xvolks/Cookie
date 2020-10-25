using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ContactLookRequestByNameMessage : ContactLookRequestMessage
    {
        public new const uint ProtocolId = 5933;
        public override uint MessageID { get { return ProtocolId; } }

        public string PlayerName;

        public ContactLookRequestByNameMessage(): base()
        {
        }

        public ContactLookRequestByNameMessage(
            byte requestId,
            byte contactType,
            string playerName
        ): base(
            requestId,
            contactType
        )
        {
            PlayerName = playerName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerName = reader.ReadUTF();
        }
    }
}