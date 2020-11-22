using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
    {
        public new const ushort ProtocolId = 6000;

        public override ushort MessageID => ProtocolId;

        public ushort ObjectGenericId { get; set; }
        public ExchangeCraftResultWithObjectIdMessage() { }

        public ExchangeCraftResultWithObjectIdMessage( ushort ObjectGenericId ){
            this.ObjectGenericId = ObjectGenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGenericId = reader.ReadVarUhShort();
        }
    }
}
