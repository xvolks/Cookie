using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const uint ProtocolId = 1010;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;
        public short SpellLevel = 0;
        public List<short> PortalsIds;

        public GameActionFightSpellCastMessage(): base()
        {
        }

        public GameActionFightSpellCastMessage(
            short actionId,
            double sourceId,
            bool silentCast,
            bool verboseCast,
            double targetId,
            short destinationCellId,
            byte critical,
            short spellId,
            short spellLevel,
            List<short> portalsIds
        ): base(
            actionId,
            sourceId,
            silentCast,
            verboseCast,
            targetId,
            destinationCellId,
            critical
        )
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
            PortalsIds = portalsIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(SpellId);
            writer.WriteShort(SpellLevel);
            writer.WriteShort((short)PortalsIds.Count());
            foreach (var current in PortalsIds)
            {
                writer.WriteShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarShort();
            SpellLevel = reader.ReadShort();
            var countPortalsIds = reader.ReadShort();
            PortalsIds = new List<short>();
            for (short i = 0; i < countPortalsIds; i++)
            {
                PortalsIds.Add(reader.ReadShort());
            }
        }
    }
}