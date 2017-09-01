namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Mount;
    using Utils.IO;

    public class PaddockItem : ObjectItemInRolePlay
    {
        public new const ushort ProtocolId = 185;
        public override ushort TypeID => ProtocolId;
        public ItemDurability Durability { get; set; }

        public PaddockItem(ItemDurability durability)
        {
            Durability = durability;
        }

        public PaddockItem() { }

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
