using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 160;
        public override short TypeId { get { return ProtocolId; } }

        public bool KeyRingBonus = false;
        public bool HasHardcoreDrop = false;
        public bool HasAVARewardToken = false;
        public GroupMonsterStaticInformations StaticInfos;
        public byte LootShare = 0;
        public byte AlignmentSide = 0;

        public GameRolePlayGroupMonsterInformations(): base()
        {
        }

        public GameRolePlayGroupMonsterInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            bool keyRingBonus,
            bool hasHardcoreDrop,
            bool hasAVARewardToken,
            GroupMonsterStaticInformations staticInfos,
            byte lootShare,
            byte alignmentSide
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            KeyRingBonus = keyRingBonus;
            HasHardcoreDrop = hasHardcoreDrop;
            HasAVARewardToken = hasAVARewardToken;
            StaticInfos = staticInfos;
            LootShare = lootShare;
            AlignmentSide = alignmentSide;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, KeyRingBonus);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, HasHardcoreDrop);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, HasAVARewardToken);
            writer.WriteByte(box0);
            writer.WriteShort(StaticInfos.TypeId);
            StaticInfos.Serialize(writer);
            writer.WriteByte(LootShare);
            writer.WriteByte(AlignmentSide);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            KeyRingBonus = BooleanByteWrapper.GetFlag(box0, 1);
            HasHardcoreDrop = BooleanByteWrapper.GetFlag(box0, 2);
            HasAVARewardToken = BooleanByteWrapper.GetFlag(box0, 3);
            var staticInfosTypeId = reader.ReadShort();
            StaticInfos = new GroupMonsterStaticInformations();
            StaticInfos.Deserialize(reader);
            LootShare = reader.ReadByte();
            AlignmentSide = reader.ReadByte();
        }
    }
}