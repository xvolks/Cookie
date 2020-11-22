using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InviteInHavenBagMessage : NetworkMessage
    {
        public const uint ProtocolId = 6642;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations GuestInformations;
        public bool Accept = false;

        public InviteInHavenBagMessage()
        {
        }

        public InviteInHavenBagMessage(
            CharacterMinimalInformations guestInformations,
            bool accept
        )
        {
            GuestInformations = guestInformations;
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            GuestInformations.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuestInformations = new CharacterMinimalInformations();
            GuestInformations.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }
    }
}