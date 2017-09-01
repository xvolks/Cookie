using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 160;

        public GameRolePlayGroupMonsterInformations(bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken,
            GroupMonsterStaticInformations staticInfos, double creationTime, int ageBonusRate, sbyte lootShare,
            sbyte alignmentSide)
        {
            KeyRingBonus = keyRingBonus;
            HasHardcoreDrop = hasHardcoreDrop;
            HasAVARewardToken = hasAVARewardToken;
            StaticInfos = staticInfos;
            CreationTime = creationTime;
            AgeBonusRate = ageBonusRate;
            LootShare = lootShare;
            AlignmentSide = alignmentSide;
        }

        public GameRolePlayGroupMonsterInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool KeyRingBonus { get; set; }
        public bool HasHardcoreDrop { get; set; }
        public bool HasAVARewardToken { get; set; }
        public GroupMonsterStaticInformations StaticInfos { get; set; }
        public double CreationTime { get; set; }
        public int AgeBonusRate { get; set; }
        public sbyte LootShare { get; set; }
        public sbyte AlignmentSide { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, KeyRingBonus);
            flag = BooleanByteWrapper.SetFlag(1, flag, HasHardcoreDrop);
            flag = BooleanByteWrapper.SetFlag(2, flag, HasAVARewardToken);
            writer.WriteByte(flag);
            writer.WriteUShort(StaticInfos.TypeID);
            StaticInfos.Serialize(writer);
            writer.WriteDouble(CreationTime);
            writer.WriteInt(AgeBonusRate);
            writer.WriteSByte(LootShare);
            writer.WriteSByte(AlignmentSide);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            KeyRingBonus = BooleanByteWrapper.GetFlag(flag, 0);
            HasHardcoreDrop = BooleanByteWrapper.GetFlag(flag, 1);
            HasAVARewardToken = BooleanByteWrapper.GetFlag(flag, 2);
            StaticInfos = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadUShort());
            StaticInfos.Deserialize(reader);
            CreationTime = reader.ReadDouble();
            AgeBonusRate = reader.ReadInt();
            LootShare = reader.ReadSByte();
            AlignmentSide = reader.ReadSByte();
        }
    }
}