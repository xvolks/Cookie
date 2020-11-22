using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SpellItem : Item
    {
        public new const ushort ProtocolId = 49;

        public override ushort TypeID => ProtocolId;

        public int SpellId { get; set; }
        public short SpellLevel { get; set; }
        public SpellItem() { }

        public SpellItem( int SpellId, short SpellLevel ){
            this.SpellId = SpellId;
            this.SpellLevel = SpellLevel;
        }

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
