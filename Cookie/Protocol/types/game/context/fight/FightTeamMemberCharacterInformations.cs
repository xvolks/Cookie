using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
    {
        public new const short ProtocolId = 13;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;
        public short Level = 0;

        public FightTeamMemberCharacterInformations(): base()
        {
        }

        public FightTeamMemberCharacterInformations(
            double id_,
            string name,
            short level
        ): base(
            id_
        )
        {
            Name = name;
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarShort(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Level = reader.ReadVarShort();
        }
    }
}