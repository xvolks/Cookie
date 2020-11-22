using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicWhoAmIRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5664;

        public override ushort MessageID => ProtocolId;

        public bool Verbose { get; set; }
        public BasicWhoAmIRequestMessage() { }

        public BasicWhoAmIRequestMessage( bool Verbose ){
            this.Verbose = Verbose;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            Verbose = reader.ReadBoolean();
        }
    }
}
