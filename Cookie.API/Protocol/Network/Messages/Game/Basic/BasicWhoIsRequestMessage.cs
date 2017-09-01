using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class BasicWhoIsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 181;

        public BasicWhoIsRequestMessage(bool verbose, string search)
        {
            Verbose = verbose;
            Search = search;
        }

        public BasicWhoIsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Verbose { get; set; }
        public string Search { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Verbose);
            writer.WriteUTF(Search);
        }

        public override void Deserialize(IDataReader reader)
        {
            Verbose = reader.ReadBoolean();
            Search = reader.ReadUTF();
        }
    }
}