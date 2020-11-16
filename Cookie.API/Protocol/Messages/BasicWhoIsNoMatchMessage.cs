using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicWhoIsNoMatchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 179;

        public override ushort MessageID => ProtocolId;

        public string Search { get; set; }
        public BasicWhoIsNoMatchMessage() { }

        public BasicWhoIsNoMatchMessage( string Search ){
            this.Search = Search;
        }

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
