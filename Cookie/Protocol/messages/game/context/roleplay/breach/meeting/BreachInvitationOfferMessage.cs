using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachInvitationOfferMessage : NetworkMessage
    {
        public const uint ProtocolId = 6805;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations Host;
        public int TimeLeftBeforeCancel = 0;

        public BreachInvitationOfferMessage()
        {
        }

        public BreachInvitationOfferMessage(
            CharacterMinimalInformations host,
            int timeLeftBeforeCancel
        )
        {
            Host = host;
            TimeLeftBeforeCancel = timeLeftBeforeCancel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Host.Serialize(writer);
            writer.WriteVarInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarInt();
        }
    }
}