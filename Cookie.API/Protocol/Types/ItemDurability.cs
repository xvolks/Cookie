using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ItemDurability : NetworkType
    {
        public const ushort ProtocolId = 168;

        public override ushort TypeID => ProtocolId;

        public short Durability { get; set; }
        public short DurabilityMax { get; set; }
        public ItemDurability() { }

        public ItemDurability( short Durability, short DurabilityMax ){
            this.Durability = Durability;
            this.DurabilityMax = DurabilityMax;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Durability);
            writer.WriteShort(DurabilityMax);
        }

        public override void Deserialize(IDataReader reader)
        {
            Durability = reader.ReadShort();
            DurabilityMax = reader.ReadShort();
        }
    }
}
