using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachSavedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6798;

        public override ushort MessageID => ProtocolId;

        public bool Saved { get; set; }
        public BreachSavedMessage() { }

        public BreachSavedMessage( bool Saved ){
            this.Saved = Saved;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Saved);
        }

        public override void Deserialize(IDataReader reader)
        {
            Saved = reader.ReadBoolean();
        }
    }
}
