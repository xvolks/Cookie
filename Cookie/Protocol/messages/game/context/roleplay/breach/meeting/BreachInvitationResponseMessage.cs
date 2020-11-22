using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachInvitationResponseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6792;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations Guest;
        public bool Accept = false;

        public BreachInvitationResponseMessage()
        {
        }

        public BreachInvitationResponseMessage(
            CharacterMinimalInformations guest,
            bool accept
        )
        {
            Guest = guest;
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Guest.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Guest = new CharacterMinimalInformations();
            Guest.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }
    }
}