using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InviteInHavenBagOfferMessage : NetworkMessage
    {
        public const uint ProtocolId = 6643;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations HostInformations;
        public int TimeLeftBeforeCancel = 0;

        public InviteInHavenBagOfferMessage()
        {
        }

        public InviteInHavenBagOfferMessage(
            CharacterMinimalInformations hostInformations,
            int timeLeftBeforeCancel
        )
        {
            HostInformations = hostInformations;
            TimeLeftBeforeCancel = timeLeftBeforeCancel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            HostInformations.Serialize(writer);
            writer.WriteVarInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarInt();
        }
    }
}