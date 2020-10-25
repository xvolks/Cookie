using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutObjectItem : ShortcutObject
    {
        public new const short ProtocolId = 371;
        public override short TypeId { get { return ProtocolId; } }

        public int ItemUID = 0;
        public int ItemGID = 0;

        public ShortcutObjectItem(): base()
        {
        }

        public ShortcutObjectItem(
            byte slot,
            int itemUID,
            int itemGID
        ): base(
            slot
        )
        {
            ItemUID = itemUID;
            ItemGID = itemGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ItemUID);
            writer.WriteInt(ItemGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ItemUID = reader.ReadInt();
            ItemGID = reader.ReadInt();
        }
    }
}