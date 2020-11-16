using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class UpdateMountBooleanCharacteristic : UpdateMountCharacteristic
    {
        public new const short ProtocolId = 538;
        public override short TypeId { get { return ProtocolId; } }

        public bool Value = false;

        public UpdateMountBooleanCharacteristic(): base()
        {
        }

        public UpdateMountBooleanCharacteristic(
            byte type,
            bool value
        ): base(
            type
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadBoolean();
        }
    }
}