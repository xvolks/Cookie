using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseTypeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5803;

        public override ushort MessageID => ProtocolId;

        public uint Type { get; set; }
        public bool Follow { get; set; }
        public ExchangeBidHouseTypeMessage() { }

        public ExchangeBidHouseTypeMessage( uint Type, bool Follow ){
            this.Type = Type;
            this.Follow = Follow;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Type);
            writer.WriteBoolean(Follow);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadVarUhInt();
            Follow = reader.ReadBoolean();
        }
    }
}
