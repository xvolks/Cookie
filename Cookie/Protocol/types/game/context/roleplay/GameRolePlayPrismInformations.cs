using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 161;
        public override short TypeId { get { return ProtocolId; } }

        public PrismInformation Prism;

        public GameRolePlayPrismInformations(): base()
        {
        }

        public GameRolePlayPrismInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            PrismInformation prism
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            Prism = prism;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Prism.TypeId);
            Prism.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var prismTypeId = reader.ReadShort();
            Prism = new PrismInformation();
            Prism.Deserialize(reader);
        }
    }
}