using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberEntityInformation : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 549;

        public override ushort TypeID => ProtocolId;

        public sbyte EntityModelId { get; set; }
        public ushort Level { get; set; }
        public double MasterId { get; set; }
        public FightTeamMemberEntityInformation() { }

        public FightTeamMemberEntityInformation( sbyte EntityModelId, ushort Level, double MasterId ){
            this.EntityModelId = EntityModelId;
            this.Level = Level;
            this.MasterId = MasterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(EntityModelId);
            writer.WriteVarUhShort(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadSByte();
            Level = reader.ReadVarUhShort();
            MasterId = reader.ReadDouble();
        }
    }
}
