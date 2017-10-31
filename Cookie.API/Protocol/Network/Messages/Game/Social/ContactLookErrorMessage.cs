namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using Utils.IO;

    public class ContactLookErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6045;
        public override ushort MessageID => ProtocolId;
        public uint RequestId { get; set; }

        public ContactLookErrorMessage(uint requestId)
        {
            RequestId = requestId;
        }

        public ContactLookErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUhInt();
        }

    }
}
