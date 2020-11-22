using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SimpleCharacterCharacteristicForPreset : NetworkType
    {
        public const ushort ProtocolId = 541;

        public override ushort TypeID => ProtocolId;

        public string Keyword { get; set; }
        public short Base { get; set; }
        public short Additionnal { get; set; }
        public SimpleCharacterCharacteristicForPreset() { }

        public SimpleCharacterCharacteristicForPreset( string Keyword, short Base, short Additionnal ){
            this.Keyword = Keyword;
            this.Base = Base;
            this.Additionnal = Additionnal;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Keyword);
            writer.WriteVarShort(Base);
            writer.WriteVarShort(Additionnal);
        }

        public override void Deserialize(IDataReader reader)
        {
            Keyword = reader.ReadUTF();
            Base = reader.ReadVarShort();
            Additionnal = reader.ReadVarShort();
        }
    }
}
