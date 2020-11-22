using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SpellVariantActivationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6705;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public bool Result { get; set; }
        public SpellVariantActivationMessage() { }

        public SpellVariantActivationMessage( ushort SpellId, bool Result ){
            this.SpellId = SpellId;
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteBoolean(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            Result = reader.ReadBoolean();
        }
    }
}
