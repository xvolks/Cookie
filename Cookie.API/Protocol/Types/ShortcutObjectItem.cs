using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ShortcutObjectItem : ShortcutObject
    {
        public new const ushort ProtocolId = 371;

        public override ushort TypeID => ProtocolId;

        public int ItemUID { get; set; }
        public int ItemGID { get; set; }
        public ShortcutObjectItem() { }

        public ShortcutObjectItem( int ItemUID, int ItemGID ){
            this.ItemUID = ItemUID;
            this.ItemGID = ItemGID;
        }

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
