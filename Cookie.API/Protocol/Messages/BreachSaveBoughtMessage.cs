using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachSaveBoughtMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6788;

        public override ushort MessageID => ProtocolId;

        public bool Bought { get; set; }
        public BreachSaveBoughtMessage() { }

        public BreachSaveBoughtMessage( bool Bought ){
            this.Bought = Bought;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bought = reader.ReadBoolean();
        }
    }
}
