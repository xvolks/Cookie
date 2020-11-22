using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SpellItem : Item
    {
        public new const short ProtocolId = 49;
        public override short TypeId { get { return ProtocolId; } }

        public int SpellId = 0;
        public short SpellLevel = 0;

        public SpellItem(): base()
        {
        }

        public SpellItem(
            int spellId,
            short spellLevel
        ): base()
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadInt();
            SpellLevel = reader.ReadShort();
        }
    }
}