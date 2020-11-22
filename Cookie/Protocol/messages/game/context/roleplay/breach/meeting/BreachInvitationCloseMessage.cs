using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachInvitationCloseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6790;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations Host;

        public BreachInvitationCloseMessage()
        {
        }

        public BreachInvitationCloseMessage(
            CharacterMinimalInformations host
        )
        {
            Host = host;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Host.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
        }
    }
}