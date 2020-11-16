using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectMinMax : ObjectEffect
    {
        public new const ushort ProtocolId = 82;

        public override ushort TypeID => ProtocolId;

        public uint Min { get; set; }
        public uint Max { get; set; }
        public ObjectEffectMinMax() { }

        public ObjectEffectMinMax( uint Min, uint Max ){
            this.Min = Min;
            this.Max = Max;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Min);
            writer.WriteVarUhInt(Max);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadVarUhInt();
            Max = reader.ReadVarUhInt();
        }
    }
}
