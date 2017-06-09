using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types.Game.Character
{
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public new const short ProtocolId = 110;
        public override short TypeID { get { return ProtocolId; } }

        public byte Level { get; set; }

        public CharacterMinimalInformations() { }

        public CharacterMinimalInformations(byte level)
        {
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
        }
    }
}
