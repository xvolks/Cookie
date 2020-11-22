using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountEquipedErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5963;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ErrorType = 0;

        public MountEquipedErrorMessage()
        {
        }

        public MountEquipedErrorMessage(
            byte errorType
        )
        {
            ErrorType = errorType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ErrorType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ErrorType = reader.ReadByte();
        }
    }
}