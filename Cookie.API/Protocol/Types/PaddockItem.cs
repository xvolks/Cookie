using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockItem : ObjectItemInRolePlay
    {
        public new const ushort ProtocolId = 185;

        public override ushort TypeID => ProtocolId;

        public ItemDurability Durability { get; set; }
        public PaddockItem() { }

        public PaddockItem( ItemDurability Durability ){
            this.Durability = Durability;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Durability.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Durability = new ItemDurability();
            Durability.Deserialize(reader);
        }
    }
}
