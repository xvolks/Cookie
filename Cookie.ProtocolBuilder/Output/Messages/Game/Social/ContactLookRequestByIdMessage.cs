namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using Utils.IO;

    public class ContactLookRequestByIdMessage : ContactLookRequestMessage
    {
        public new const ushort ProtocolId = 5935;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public ContactLookRequestByIdMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public ContactLookRequestByIdMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
