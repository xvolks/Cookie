namespace Cookie.API.Protocol.Network.Messages.Game.Character.Deletion
{
    using Utils.IO;

    public class CharacterDeletionErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 166;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public CharacterDeletionErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public CharacterDeletionErrorMessage() { }

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
