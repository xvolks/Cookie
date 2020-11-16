using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicWhoIsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 181;

        public override ushort MessageID => ProtocolId;

        public bool Verbose { get; set; }
        public string Search { get; set; }
        public BasicWhoIsRequestMessage() { }

        public BasicWhoIsRequestMessage( bool Verbose, string Search ){
            this.Verbose = Verbose;
            this.Search = Search;
        }

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
