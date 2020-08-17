namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountEquipedErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5963;
        public override ushort MessageID => ProtocolId;
        public byte ErrorType { get; set; }

        public MountEquipedErrorMessage(byte errorType)
        {
            ErrorType = errorType;
        }

        public MountEquipedErrorMessage() { }

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
