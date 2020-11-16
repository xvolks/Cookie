using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayPortalInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 467;
        public override short TypeId { get { return ProtocolId; } }

        public PortalInformation Portal;

        public GameRolePlayPortalInformations(): base()
        {
        }

        public GameRolePlayPortalInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            PortalInformation portal
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            Portal = portal;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Portal.TypeId);
            Portal.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var portalTypeId = reader.ReadShort();
            Portal = new PortalInformation();
            Portal.Deserialize(reader);
        }
    }
}