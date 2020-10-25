using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionObjectUse : HumanOption
    {
        public new const short ProtocolId = 449;
        public override short TypeId { get { return ProtocolId; } }

        public byte DelayTypeId = 0;
        public double DelayEndTime = 0;
        public short ObjectGID = 0;

        public HumanOptionObjectUse(): base()
        {
        }

        public HumanOptionObjectUse(
            byte delayTypeId,
            double delayEndTime,
            short objectGID
        ): base()
        {
            DelayTypeId = delayTypeId;
            DelayEndTime = delayEndTime;
            ObjectGID = objectGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
            writer.WriteVarShort(ObjectGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DelayTypeId = reader.ReadByte();
            DelayEndTime = reader.ReadDouble();
            ObjectGID = reader.ReadVarShort();
        }
    }
}