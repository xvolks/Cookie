using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public new const short ProtocolId = 36;
        public override short TypeId { get { return ProtocolId; } }

        public ActorAlignmentInformations AlignmentInfos;

        public GameRolePlayCharacterInformations(): base()
        {
        }

        public GameRolePlayCharacterInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name,
            HumanInformations humanoidInfo,
            int accountId,
            ActorAlignmentInformations alignmentInfos
        ): base(
            contextualId,
            look,
            disposition,
            name,
            humanoidInfo,
            accountId
        )
        {
            AlignmentInfos = alignmentInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }
    }
}