using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountEquipedErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5963;

        public override ushort MessageID => ProtocolId;

        public sbyte ErrorType { get; set; }
        public MountEquipedErrorMessage() { }

        public MountEquipedErrorMessage( sbyte ErrorType ){
            this.ErrorType = ErrorType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ErrorType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorType = reader.ReadSByte();
        }
    }
}
