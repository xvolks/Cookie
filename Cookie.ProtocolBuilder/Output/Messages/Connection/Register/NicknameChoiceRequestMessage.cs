namespace Cookie.API.Protocol.Network.Messages.Connection.Register
{
    using Utils.IO;

    public class NicknameChoiceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5639;
        public override ushort MessageID => ProtocolId;
        public string Nickname { get; set; }

        public NicknameChoiceRequestMessage(string nickname)
        {
            Nickname = nickname;
        }

        public NicknameChoiceRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Nickname);
        }

        public override void Deserialize(IDataReader reader)
        {
            Nickname = reader.ReadUTF();
        }

    }
}
