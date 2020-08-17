namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutObjectItem : ShortcutObject
    {
        public new const ushort ProtocolId = 371;
        public override ushort TypeID => ProtocolId;
        public int ItemUID { get; set; }
        public int ItemGID { get; set; }

        public ShortcutObjectItem(int itemUID, int itemGID)
        {
            ItemUID = itemUID;
            ItemGID = itemGID;
        }

        public ShortcutObjectItem() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ItemUID);
            writer.WriteInt(ItemGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ItemUID = reader.ReadInt();
            ItemGID = reader.ReadInt();
        }

    }
}
