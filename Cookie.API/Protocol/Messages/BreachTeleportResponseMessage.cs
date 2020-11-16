using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachTeleportResponseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6816;

        public override ushort MessageID => ProtocolId;

        public bool Teleported { get; set; }
        public BreachTeleportResponseMessage() { }

        public BreachTeleportResponseMessage( bool Teleported ){
            this.Teleported = Teleported;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Teleported);
        }

        public override void Deserialize(IDataReader reader)
        {
            Teleported = reader.ReadBoolean();
        }
    }
}
