using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicWhoIsNoMatchMessage : NetworkMessage
    {
        public const uint ProtocolId = 179;
        public override uint MessageID { get { return ProtocolId; } }

        public string Search;

        public BasicWhoIsNoMatchMessage()
        {
        }

        public BasicWhoIsNoMatchMessage(
            string search
        )
        {
            Search = search;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Search);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Search = reader.ReadUTF();
        }
    }
}