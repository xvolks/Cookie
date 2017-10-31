namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    using Utils.IO;

    public class LockableCodeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5672;
        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public LockableCodeResultMessage(byte result)
        {
            Result = result;
        }

        public LockableCodeResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadByte();
        }

    }
}
