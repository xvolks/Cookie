using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class BasicWhoIsNoMatchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 179;

        public BasicWhoIsNoMatchMessage(string search)
        {
            Search = search;
        }

        public BasicWhoIsNoMatchMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Search { get; set; }

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