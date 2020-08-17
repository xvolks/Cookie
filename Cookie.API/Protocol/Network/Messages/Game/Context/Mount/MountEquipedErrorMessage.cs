using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountEquipedErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5963;

        public MountEquipedErrorMessage(byte errorType)
        {
            ErrorType = errorType;
        }

        public MountEquipedErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte ErrorType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ErrorType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorType = reader.ReadByte();
        }
    }
}