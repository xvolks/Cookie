using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const ushort ProtocolId = 1010;

        public GameActionFightSpellCastMessage(ushort spellId, short spellLevel, List<short> portalsIds)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
            PortalsIds = portalsIds;
        }

        public GameActionFightSpellCastMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }
        public List<short> PortalsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(SpellLevel);
            writer.WriteShort((short) PortalsIds.Count);
            for (var portalsIdsIndex = 0; portalsIdsIndex < PortalsIds.Count; portalsIdsIndex++)
                writer.WriteShort(PortalsIds[portalsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUhShort();
            SpellLevel = reader.ReadShort();
            var portalsIdsCount = reader.ReadUShort();
            PortalsIds = new List<short>();
            for (var portalsIdsIndex = 0; portalsIdsIndex < portalsIdsCount; portalsIdsIndex++)
                PortalsIds.Add(reader.ReadShort());
        }
    }
}