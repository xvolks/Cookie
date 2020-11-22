using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SpellVariantActivationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6707;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public SpellVariantActivationRequestMessage() { }

        public SpellVariantActivationRequestMessage( ushort SpellId ){
            this.SpellId = SpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
        }
    }
}
