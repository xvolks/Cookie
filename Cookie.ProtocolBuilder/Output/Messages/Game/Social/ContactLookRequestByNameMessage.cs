namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using Utils.IO;

    public class ContactLookRequestByNameMessage : ContactLookRequestMessage
    {
        public new const ushort ProtocolId = 5933;
        public override ushort MessageID => ProtocolId;
        public string PlayerName { get; set; }

        public ContactLookRequestByNameMessage(string playerName)
        {
            PlayerName = playerName;
        }

        public ContactLookRequestByNameMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerName = reader.ReadUTF();
        }

    }
}
