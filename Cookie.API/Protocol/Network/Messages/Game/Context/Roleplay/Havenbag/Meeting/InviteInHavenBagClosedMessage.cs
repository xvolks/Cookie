using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class InviteInHavenBagClosedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6645;

        public InviteInHavenBagClosedMessage(CharacterMinimalInformations hostInformations)
        {
            HostInformations = hostInformations;
        }

        public InviteInHavenBagClosedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public CharacterMinimalInformations HostInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
        }
    }
}