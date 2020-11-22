using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionTitle : HumanOption
    {
        public new const ushort ProtocolId = 408;

        public override ushort TypeID => ProtocolId;

        public ushort TitleId { get; set; }
        public string TitleParam { get; set; }
        public HumanOptionTitle() { }

        public HumanOptionTitle( ushort TitleId, string TitleParam ){
            this.TitleId = TitleId;
            this.TitleParam = TitleParam;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(TitleId);
            writer.WriteUTF(TitleParam);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TitleId = reader.ReadVarUhShort();
            TitleParam = reader.ReadUTF();
        }
    }
}
