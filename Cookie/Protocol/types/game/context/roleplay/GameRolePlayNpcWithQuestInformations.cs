using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public new const short ProtocolId = 383;
        public override short TypeId { get { return ProtocolId; } }

        public GameRolePlayNpcQuestFlag QuestFlag;

        public GameRolePlayNpcWithQuestInformations(): base()
        {
        }

        public GameRolePlayNpcWithQuestInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            short npcId,
            bool sex,
            short specialArtworkId,
            GameRolePlayNpcQuestFlag questFlag
        ): base(
            contextualId,
            look,
            disposition,
            npcId,
            sex,
            specialArtworkId
        )
        {
            QuestFlag = questFlag;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            QuestFlag.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            QuestFlag = new GameRolePlayNpcQuestFlag();
            QuestFlag.Deserialize(reader);
        }
    }
}