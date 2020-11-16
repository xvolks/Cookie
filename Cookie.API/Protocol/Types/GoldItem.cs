using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GoldItem : Item
    {
        public new const ushort ProtocolId = 123;

        public override ushort TypeID => ProtocolId;

        public ulong Sum { get; set; }
        public GoldItem() { }

        public GoldItem( ulong Sum ){
            this.Sum = Sum;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Sum);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Sum = reader.ReadVarUhLong();
        }
    }
}
