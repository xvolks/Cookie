using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5585;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;

        public PartyInvitationRequestMessage()
        {
        }

        public PartyInvitationRequestMessage(
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