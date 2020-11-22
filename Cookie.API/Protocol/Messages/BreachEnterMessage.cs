using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachEnterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6810;

        public override ushort MessageID => ProtocolId;

        public ulong Owner { get; set; }
        public BreachEnterMessage() { }

        public BreachEnterMessage( ulong Owner ){
            this.Owner = Owner;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Owner);
        }

        public override void Deserialize(IDataReader reader)
        {
            Owner = reader.ReadVarUhLong();
        }
    }
}
