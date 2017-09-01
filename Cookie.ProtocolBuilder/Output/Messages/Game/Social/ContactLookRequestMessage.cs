namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using Utils.IO;

    public class ContactLookRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5932;
        public override ushort MessageID => ProtocolId;
        public byte RequestId { get; set; }
        public byte ContactType { get; set; }

        public ContactLookRequestMessage(byte requestId, byte contactType)
        {
            RequestId = requestId;
            ContactType = contactType;
        }

        public ContactLookRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RequestId);
            writer.WriteByte(ContactType);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadByte();
            ContactType = reader.ReadByte();
        }

    }
}
