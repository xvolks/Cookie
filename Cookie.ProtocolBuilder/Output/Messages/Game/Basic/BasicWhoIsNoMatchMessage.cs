namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicWhoIsNoMatchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 179;
        public override ushort MessageID => ProtocolId;
        public string Search { get; set; }

        public BasicWhoIsNoMatchMessage(string search)
        {
            Search = search;
        }

        public BasicWhoIsNoMatchMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Search);
        }

        public override void Deserialize(IDataReader reader)
        {
            Search = reader.ReadUTF();
        }

    }
}
