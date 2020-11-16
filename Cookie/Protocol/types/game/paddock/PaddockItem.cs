using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockItem : ObjectItemInRolePlay
    {
        public new const short ProtocolId = 185;
        public override short TypeId { get { return ProtocolId; } }

        public ItemDurability Durability;

        public PaddockItem(): base()
        {
        }

        public PaddockItem(
            short cellId,
            short objectGID,
            ItemDurability durability
        ): base(
            cellId,
            objectGID
        )
        {
            Durability = durability;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Durability.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Durability = new ItemDurability();
            Durability.Deserialize(reader);
        }
    }
}