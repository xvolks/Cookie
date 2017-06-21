using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.Character
{
    public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 193;

        public CharacterMinimalPlusLookAndGradeInformations()
        {
        }

        public CharacterMinimalPlusLookAndGradeInformations(uint grade)
        {
            Grade = grade;
        }

        public override short TypeID => ProtocolId;

        public uint Grade { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Grade);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadVarUhInt();
        }
    }
}