using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class InviteInHavenBagOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6643;

        public InviteInHavenBagOfferMessage(CharacterMinimalInformations hostInformations, int timeLeftBeforeCancel)
        {
            HostInformations = hostInformations;
            TimeLeftBeforeCancel = timeLeftBeforeCancel;
        }

        public InviteInHavenBagOfferMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public CharacterMinimalInformations HostInformations { get; set; }
        public int TimeLeftBeforeCancel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
            writer.WriteVarInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarInt();
        }
    }
}