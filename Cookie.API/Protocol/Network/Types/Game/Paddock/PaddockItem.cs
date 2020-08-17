using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.Mount;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    public class PaddockItem : ObjectItemInRolePlay
    {
        public new const ushort ProtocolId = 185;

        public PaddockItem(ItemDurability durability)
        {
            Durability = durability;
        }

        public PaddockItem()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ItemDurability Durability { get; set; }

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