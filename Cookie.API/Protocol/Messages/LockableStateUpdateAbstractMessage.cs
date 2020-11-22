using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LockableStateUpdateAbstractMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5671;

        public override ushort MessageID => ProtocolId;

        public bool Locked { get; set; }
        public LockableStateUpdateAbstractMessage() { }

        public LockableStateUpdateAbstractMessage( bool Locked ){
            this.Locked = Locked;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Locked = reader.ReadBoolean();
        }
    }
}
