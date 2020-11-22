using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public new const short ProtocolId = 203;
        public override short TypeId { get { return ProtocolId; } }

        public ActorAlignmentInformations AlignmentInfos;

        public GameFightMonsterWithAlignmentInformations(): base()
        {
        }

        public GameFightMonsterWithAlignmentInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions,
            short creatureGenericId,
            byte creatureGrade,
            short creatureLevel,
            ActorAlignmentInformations alignmentInfos
        ): base(
            contextualId,
            look,
            disposition,
            teamId,
            wave,
            alive,
            stats,
            previousPositions,
            creatureGenericId,
            creatureGrade,
            creatureLevel
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