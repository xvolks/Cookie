using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public new const ushort ProtocolId = 115;

        public FightTeamLightInformations(bool hasFriend, bool hasGuildMember, bool hasAllianceMember,
            bool hasGroupMember, bool hasMyTaxCollector, byte teamMembersCount, uint meanLevel)
        {
            HasFriend = hasFriend;
            HasGuildMember = hasGuildMember;
            HasAllianceMember = hasAllianceMember;
            HasGroupMember = hasGroupMember;
            HasMyTaxCollector = hasMyTaxCollector;
            TeamMembersCount = teamMembersCount;
            MeanLevel = meanLevel;
        }

        public FightTeamLightInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool HasFriend { get; set; }
        public bool HasGuildMember { get; set; }
        public bool HasAllianceMember { get; set; }
        public bool HasGroupMember { get; set; }
        public bool HasMyTaxCollector { get; set; }
        public byte TeamMembersCount { get; set; }
        public uint MeanLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, HasFriend);
            flag = BooleanByteWrapper.SetFlag(1, flag, HasGuildMember);
            flag = BooleanByteWrapper.SetFlag(2, flag, HasAllianceMember);
            flag = BooleanByteWrapper.SetFlag(3, flag, HasGroupMember);
            flag = BooleanByteWrapper.SetFlag(4, flag, HasMyTaxCollector);
            writer.WriteByte(flag);
            writer.WriteByte(TeamMembersCount);
            writer.WriteVarUhInt(MeanLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            HasFriend = BooleanByteWrapper.GetFlag(flag, 0);
            HasGuildMember = BooleanByteWrapper.GetFlag(flag, 1);
            HasAllianceMember = BooleanByteWrapper.GetFlag(flag, 2);
            HasGroupMember = BooleanByteWrapper.GetFlag(flag, 3);
            HasMyTaxCollector = BooleanByteWrapper.GetFlag(flag, 4);
            TeamMembersCount = reader.ReadByte();
            MeanLevel = reader.ReadVarUhInt();
        }
    }
}