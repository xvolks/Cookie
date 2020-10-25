using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
    {
        public new const short ProtocolId = 177;
        public override short TypeId { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;
        public byte Level = 0;
        public int GuildId = 0;
        public double Uid = 0;

        public FightTeamMemberTaxCollectorInformations(): base()
        {
        }

        public FightTeamMemberTaxCollectorInformations(
            double id_,
            short firstNameId,
            short lastNameId,
            byte level,
            int guildId,
            double uid
        ): base(
            id_
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
            GuildId = guildId;
            Uid = uid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
            writer.WriteByte(Level);
            writer.WriteVarInt(GuildId);
            writer.WriteDouble(Uid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            Level = reader.ReadByte();
            GuildId = reader.ReadVarInt();
            Uid = reader.ReadDouble();
        }
    }
}