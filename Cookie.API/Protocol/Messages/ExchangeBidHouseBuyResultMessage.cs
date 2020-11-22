using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseBuyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6272;

        public override ushort MessageID => ProtocolId;

        public uint Uid { get; set; }
        public bool Bought { get; set; }
        public ExchangeBidHouseBuyResultMessage() { }

        public ExchangeBidHouseBuyResultMessage( uint Uid, bool Bought ){
            this.Uid = Uid;
            this.Bought = Bought;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            Bought = reader.ReadBoolean();
        }
    }
}
