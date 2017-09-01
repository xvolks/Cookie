using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Deletion
{
    public class CharacterDeletionErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 166;

        public CharacterDeletionErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public CharacterDeletionErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}