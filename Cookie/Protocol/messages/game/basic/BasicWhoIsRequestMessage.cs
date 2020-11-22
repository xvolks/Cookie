using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicWhoIsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 181;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Verbose = false;
        public string Search;

        public BasicWhoIsRequestMessage()
        {
        }

        public BasicWhoIsRequestMessage(
            bool verbose,
            string search
        )
        {
            Verbose = verbose;
            Search = search;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Verbose);
            writer.WriteUTF(Search);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Verbose = reader.ReadBoolean();
            Search = reader.ReadUTF();
        }
    }
}