using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberEntityInformation : FightTeamMemberInformations
    {
        public new const short ProtocolId = 549;
        public override short TypeId { get { return ProtocolId; } }

        public byte EntityModelId = 0;
        public short Level = 0;
        public double MasterId = 0;

        public FightTeamMemberEntityInformation(): base()
        {
        }

        public FightTeamMemberEntityInformation(
            double id_,
            byte entityModelId,
            short level,
            double masterId
        ): base(
            id_
        )
        {
            EntityModelId = entityModelId;
            Level = level;
            MasterId = masterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EntityModelId);
            writer.WriteVarShort(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadByte();
            Level = reader.ReadVarShort();
            MasterId = reader.ReadDouble();
        }
    }
}