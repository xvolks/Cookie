using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class UpdateMountCharacteristic : NetworkType
    {
        public const ushort ProtocolId = 536;

        public override ushort TypeID => ProtocolId;

        public sbyte Type { get; set; }
        public UpdateMountCharacteristic() { }

        public UpdateMountCharacteristic( sbyte Type ){
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
        }
    }
}
