namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    using Utils.IO;

    public class SpellItem : Item
    {
        public new const ushort ProtocolId = 49;
        public override ushort TypeID => ProtocolId;
        public int SpellId { get; set; }
        public short SpellLevel { get; set; }

        public SpellItem(int spellId, short spellLevel)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public SpellItem() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadInt();
            SpellLevel = reader.ReadShort();
        }

    }
}
