using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseSearchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5806;

        public override ushort MessageID => ProtocolId;

        public uint Type { get; set; }
        public ushort GenId { get; set; }
        public ExchangeBidHouseSearchMessage() { }

        public ExchangeBidHouseSearchMessage( uint Type, ushort GenId ){
            this.Type = Type;
            this.GenId = GenId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Type);
            writer.WriteVarUhShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadVarUhInt();
            GenId = reader.ReadVarUhShort();
        }
    }
}
