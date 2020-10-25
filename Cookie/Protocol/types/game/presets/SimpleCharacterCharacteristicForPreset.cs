using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SimpleCharacterCharacteristicForPreset : NetworkType
    {
        public const short ProtocolId = 541;
        public override short TypeId { get { return ProtocolId; } }

        public string Keyword;
        public short Base_ = 0;
        public short Additionnal = 0;

        public SimpleCharacterCharacteristicForPreset()
        {
        }

        public SimpleCharacterCharacteristicForPreset(
            string keyword,
            short base_,
            short additionnal
        )
        {
            Keyword = keyword;
            Base_ = base_;
            Additionnal = additionnal;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Keyword);
            writer.WriteVarShort(Base_);
            writer.WriteVarShort(Additionnal);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Keyword = reader.ReadUTF();
            Base_ = reader.ReadVarShort();
            Additionnal = reader.ReadVarShort();
        }
    }
}