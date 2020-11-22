using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 160;

        public override ushort TypeID => ProtocolId;

        public bool KeyRingBonus { get; set; }
        public bool HasHardcoreDrop { get; set; }
        public bool HasAVARewardToken { get; set; }
        public GroupMonsterStaticInformations StaticInfos { get; set; }
        public sbyte LootShare { get; set; }
        public sbyte AlignmentSide { get; set; }
        public GameRolePlayGroupMonsterInformations() { }

        public GameRolePlayGroupMonsterInformations( bool KeyRingBonus, bool HasHardcoreDrop, bool HasAVARewardToken, GroupMonsterStaticInformations StaticInfos, sbyte LootShare, sbyte AlignmentSide ){
            this.KeyRingBonus = KeyRingBonus;
            this.HasHardcoreDrop = HasHardcoreDrop;
            this.HasAVARewardToken = HasAVARewardToken;
            this.StaticInfos = StaticInfos;
            this.LootShare = LootShare;
            this.AlignmentSide = AlignmentSide;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, KeyRingBonus);
			flag = BooleanByteWrapper.SetFlag(1, flag, HasHardcoreDrop);
			flag = BooleanByteWrapper.SetFlag(2, flag, HasAVARewardToken);
			writer.WriteByte(flag);
            StaticInfos.Serialize(writer);
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
            StaticInfos = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            StaticInfos.Deserialize(reader);
            LootShare = reader.ReadSByte();
            AlignmentSide = reader.ReadSByte();
        }
    }
}
