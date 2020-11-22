using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class InteractiveElementNamedSkill : InteractiveElementSkill
    {
        public new const ushort ProtocolId = 220;

        public override ushort TypeID => ProtocolId;

        public uint NameId { get; set; }
        public InteractiveElementNamedSkill() { }

        public InteractiveElementNamedSkill( uint NameId ){
            this.NameId = NameId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(NameId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NameId = reader.ReadVarUhInt();
        }
    }
}
