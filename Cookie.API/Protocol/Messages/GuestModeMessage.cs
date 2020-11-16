using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuestModeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6505;

        public override ushort MessageID => ProtocolId;

        public bool Active { get; set; }
        public GuestModeMessage() { }

        public GuestModeMessage( bool Active ){
            this.Active = Active;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            Active = reader.ReadBoolean();
        }
    }
}
