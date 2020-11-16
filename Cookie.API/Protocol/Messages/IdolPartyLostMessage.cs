using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolPartyLostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6580;

        public override ushort MessageID => ProtocolId;

        public ushort IdolId { get; set; }
        public IdolPartyLostMessage() { }

        public IdolPartyLostMessage( ushort IdolId ){
            this.IdolId = IdolId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolId = reader.ReadVarUhShort();
        }
    }
}
