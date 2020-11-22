using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class UpdateMountIntegerCharacteristic : UpdateMountCharacteristic
    {
        public new const short ProtocolId = 537;
        public override short TypeId { get { return ProtocolId; } }

        public int Value = 0;

        public UpdateMountIntegerCharacteristic(): base()
        {
        }

        public UpdateMountIntegerCharacteristic(
            byte type,
            int value
        ): base(
            type
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}