namespace Cookie.API.Protocol.Network.Messages.Connection.Search
{
    using Utils.IO;

    public class AcquaintanceSearchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6144;
        public override ushort MessageID => ProtocolId;
        public string Nickname { get; set; }

        public AcquaintanceSearchMessage(string nickname)
        {
            Nickname = nickname;
        }

        public AcquaintanceSearchMessage() { }

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
