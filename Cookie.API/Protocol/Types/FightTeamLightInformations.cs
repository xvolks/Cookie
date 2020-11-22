using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public new const ushort ProtocolId = 115;

        public override ushort TypeID => ProtocolId;

        public bool HasFriend { get; set; }
        public bool HasGuildMember { get; set; }
        public bool HasAllianceMember { get; set; }
        public bool HasGroupMember { get; set; }
        public bool HasMyTaxCollector { get; set; }
        public sbyte TeamMembersCount { get; set; }
        public uint MeanLevel { get; set; }
        public FightTeamLightInformations() { }

        public FightTeamLightInformations( bool HasFriend, bool HasGuildMember, bool HasAllianceMember, bool HasGroupMember, bool HasMyTaxCollector, sbyte TeamMembersCount, uint MeanLevel ){
            this.HasFriend = HasFriend;
            this.HasGuildMember = HasGuildMember;
            this.HasAllianceMember = HasAllianceMember;
            this.HasGroupMember = HasGroupMember;
            this.HasMyTaxCollector = HasMyTaxCollector;
            this.TeamMembersCount = TeamMembersCount;
            this.MeanLevel = MeanLevel;
        }

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
            writer.WriteSByte(TeamMembersCount);
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
            TeamMembersCount = reader.ReadSByte();
            MeanLevel = reader.ReadVarUhInt();
        }
    }
}
