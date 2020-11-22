using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobAllowMultiCraftRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5748;

        public override ushort MessageID => ProtocolId;

        public bool Enabled { get; set; }
        public JobAllowMultiCraftRequestMessage() { }

        public JobAllowMultiCraftRequestMessage( bool Enabled ){
            this.Enabled = Enabled;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enabled = reader.ReadBoolean();
        }
    }
}
