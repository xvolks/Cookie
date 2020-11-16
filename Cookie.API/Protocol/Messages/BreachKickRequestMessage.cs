using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6804;

        public override ushort MessageID => ProtocolId;

        public ulong Target { get; set; }
        public BreachKickRequestMessage() { }

        public BreachKickRequestMessage( ulong Target ){
            this.Target = Target;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            Target = reader.ReadVarUhLong();
        }
    }
}
