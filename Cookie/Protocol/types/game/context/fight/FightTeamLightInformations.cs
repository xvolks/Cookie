using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public new const short ProtocolId = 115;
        public override short TypeId { get { return ProtocolId; } }

        public bool HasFriend = false;
        public bool HasGuildMember = false;
        public bool HasAllianceMember = false;
        public bool HasGroupMember = false;
        public bool HasMyTaxCollector = false;
        public byte TeamMembersCount = 0;
        public int MeanLevel = 0;

        public FightTeamLightInformations(): base()
        {
        }

        public FightTeamLightInformations(
            byte teamId,
            double leaderId,
            byte teamSide,
            byte teamTypeId,
            byte nbWaves,
            bool hasFriend,
            bool hasGuildMember,
            bool hasAllianceMember,
            bool hasGroupMember,
            bool hasMyTaxCollector,
            byte teamMembersCount,
            int meanLevel
        ): base(
            teamId,
            leaderId,
            teamSide,
            teamTypeId,
            nbWaves
        )
        {
            HasFriend = hasFriend;
            HasGuildMember = hasGuildMember;
            HasAllianceMember = hasAllianceMember;
            HasGroupMember = hasGroupMember;
            HasMyTaxCollector = hasMyTaxCollector;
            TeamMembersCount = teamMembersCount;
            MeanLevel = meanLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, HasFriend);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, HasGuildMember);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, HasAllianceMember);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, HasGroupMember);
            box0 = BooleanByteWrapper.SetFlag(box0, 5, HasMyTaxCollector);
            writer.WriteByte(box0);
            writer.WriteByte(TeamMembersCount);
            writer.WriteVarInt(MeanLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            HasFriend = BooleanByteWrapper.GetFlag(box0, 1);
            HasGuildMember = BooleanByteWrapper.GetFlag(box0, 2);
            HasAllianceMember = BooleanByteWrapper.GetFlag(box0, 3);
            HasGroupMember = BooleanByteWrapper.GetFlag(box0, 4);
            HasMyTaxCollector = BooleanByteWrapper.GetFlag(box0, 5);
            TeamMembersCount = reader.ReadByte();
            MeanLevel = reader.ReadVarInt();
        }
    }
}