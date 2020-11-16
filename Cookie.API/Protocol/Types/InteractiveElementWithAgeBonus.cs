using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class InteractiveElementWithAgeBonus : InteractiveElement
    {
        public new const ushort ProtocolId = 398;

        public override ushort TypeID => ProtocolId;

        public short AgeBonus { get; set; }
        public InteractiveElementWithAgeBonus() { }

        public InteractiveElementWithAgeBonus( short AgeBonus ){
            this.AgeBonus = AgeBonus;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(AgeBonus);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AgeBonus = reader.ReadShort();
        }
    }
}
