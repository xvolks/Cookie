using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public new const ushort ProtocolId = 103;

        public override ushort TypeID => ProtocolId;

        public byte Time { get; set; }
        public SkillActionDescriptionTimed() { }

        public SkillActionDescriptionTimed( byte Time ){
            this.Time = Time;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Time);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Time = reader.ReadByte();
        }
    }
}
