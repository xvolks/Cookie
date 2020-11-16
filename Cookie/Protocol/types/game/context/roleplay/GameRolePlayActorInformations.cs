using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public new const short ProtocolId = 141;
        public override short TypeId { get { return ProtocolId; } }

        public GameRolePlayActorInformations(): base()
        {
        }

        public GameRolePlayActorInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition
        ): base(
            contextualId,
            look,
            disposition
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}