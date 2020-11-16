using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public new const ushort ProtocolId = 164;

        public override ushort TypeID => ProtocolId;

        public int UnsoldDelay { get; set; }
        public ObjectItemToSellInBid() { }

        public ObjectItemToSellInBid( int UnsoldDelay ){
            this.UnsoldDelay = UnsoldDelay;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(UnsoldDelay);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            UnsoldDelay = reader.ReadInt();
        }
    }
}
