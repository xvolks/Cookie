using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachExitResponseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6814;

        public override ushort MessageID => ProtocolId;

        public bool Exited { get; set; }
        public BreachExitResponseMessage() { }

        public BreachExitResponseMessage( bool Exited ){
            this.Exited = Exited;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Exited);
        }

        public override void Deserialize(IDataReader reader)
        {
            Exited = reader.ReadBoolean();
        }
    }
}
