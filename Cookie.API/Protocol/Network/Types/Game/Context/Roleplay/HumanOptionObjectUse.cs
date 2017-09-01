using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanOptionObjectUse : HumanOption
    {
        public new const ushort ProtocolId = 449;

        public HumanOptionObjectUse(byte delayTypeId, double delayEndTime, ushort objectGID)
        {
            DelayTypeId = delayTypeId;
            DelayEndTime = delayEndTime;
            ObjectGID = objectGID;
        }

        public HumanOptionObjectUse()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte DelayTypeId { get; set; }
        public double DelayEndTime { get; set; }
        public ushort ObjectGID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DelayTypeId = reader.ReadByte();
            DelayEndTime = reader.ReadDouble();
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}