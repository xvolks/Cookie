using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class UpdateMountCharacteristic : NetworkType
    {
        public const short ProtocolId = 536;
        public override short TypeId { get { return ProtocolId; } }

        public byte Type = 0;

        public UpdateMountCharacteristic()
        {
        }

        public UpdateMountCharacteristic(
            byte type
        )
        {
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
        }
    }
}