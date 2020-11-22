using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionEmote : HumanOption
    {
        public new const ushort ProtocolId = 407;

        public override ushort TypeID => ProtocolId;

        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }
        public HumanOptionEmote() { }

        public HumanOptionEmote( byte EmoteId, double EmoteStartTime ){
            this.EmoteId = EmoteId;
            this.EmoteStartTime = EmoteStartTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}
