using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 6;

        public override ushort TypeID => ProtocolId;

        public int MonsterId { get; set; }
        public sbyte Grade { get; set; }
        public FightTeamMemberMonsterInformations() { }

        public FightTeamMemberMonsterInformations( int MonsterId, sbyte Grade ){
            this.MonsterId = MonsterId;
            this.Grade = Grade;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MonsterId);
            writer.WriteSByte(Grade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadInt();
            Grade = reader.ReadSByte();
        }
    }
}
