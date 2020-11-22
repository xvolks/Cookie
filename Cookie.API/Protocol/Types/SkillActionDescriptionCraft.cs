using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public new const ushort ProtocolId = 100;

        public override ushort TypeID => ProtocolId;

        public sbyte Probability { get; set; }
        public SkillActionDescriptionCraft() { }

        public SkillActionDescriptionCraft( sbyte Probability ){
            this.Probability = Probability;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Probability);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Probability = reader.ReadSByte();
        }
    }
}
