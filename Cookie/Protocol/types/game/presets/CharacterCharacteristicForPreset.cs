using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterCharacteristicForPreset : SimpleCharacterCharacteristicForPreset
    {
        public new const short ProtocolId = 539;
        public override short TypeId { get { return ProtocolId; } }

        public short Stuff = 0;

        public CharacterCharacteristicForPreset(): base()
        {
        }

        public CharacterCharacteristicForPreset(
            string keyword,
            short base_,
            short additionnal,
            short stuff
        ): base(
            keyword,
            base_,
            additionnal
        )
        {
            Stuff = stuff;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Stuff);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Stuff = reader.ReadVarShort();
        }
    }
}