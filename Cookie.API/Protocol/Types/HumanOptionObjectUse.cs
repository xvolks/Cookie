using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionObjectUse : HumanOption
    {
        public new const ushort ProtocolId = 449;

        public override ushort TypeID => ProtocolId;

        public sbyte DelayTypeId { get; set; }
        public double DelayEndTime { get; set; }
        public ushort ObjectGID { get; set; }
        public HumanOptionObjectUse() { }

        public HumanOptionObjectUse( sbyte DelayTypeId, double DelayEndTime, ushort ObjectGID ){
            this.DelayTypeId = DelayTypeId;
            this.DelayEndTime = DelayEndTime;
            this.ObjectGID = ObjectGID;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DelayTypeId = reader.ReadSByte();
            DelayEndTime = reader.ReadDouble();
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}
