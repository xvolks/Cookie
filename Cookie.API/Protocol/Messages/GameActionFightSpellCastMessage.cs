using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const ushort ProtocolId = 1010;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }
        public List<short> PortalsIds { get; set; }
        public GameActionFightSpellCastMessage() { }

        public GameActionFightSpellCastMessage( ushort SpellId, short SpellLevel, List<short> PortalsIds ){
            this.SpellId = SpellId;
            this.SpellLevel = SpellLevel;
            this.PortalsIds = PortalsIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(SpellLevel);
			writer.WriteShort((short)PortalsIds.Count);
			foreach (var x in PortalsIds)
			{
				writer.WriteShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUhShort();
            SpellLevel = reader.ReadShort();
            var PortalsIdsCount = reader.ReadShort();
            PortalsIds = new List<short>();
            for (var i = 0; i < PortalsIdsCount; i++)
            {
                PortalsIds.Add(reader.ReadShort());
            }
        }
    }
}
