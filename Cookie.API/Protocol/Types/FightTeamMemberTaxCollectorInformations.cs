using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 177;

        public override ushort TypeID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public byte Level { get; set; }
        public uint GuildId { get; set; }
        public double Uid { get; set; }
        public FightTeamMemberTaxCollectorInformations() { }

        public FightTeamMemberTaxCollectorInformations( ushort FirstNameId, ushort LastNameId, byte Level, uint GuildId, double Uid ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
            this.Level = Level;
            this.GuildId = GuildId;
            this.Uid = Uid;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteByte(Level);
            writer.WriteVarUhInt(GuildId);
            writer.WriteDouble(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            Level = reader.ReadByte();
            GuildId = reader.ReadVarUhInt();
            Uid = reader.ReadDouble();
        }
    }
}
