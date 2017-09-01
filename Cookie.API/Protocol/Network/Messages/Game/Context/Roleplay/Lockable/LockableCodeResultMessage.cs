using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    public class LockableCodeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5672;

        public LockableCodeResultMessage(byte result)
        {
            Result = result;
        }

        public LockableCodeResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

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