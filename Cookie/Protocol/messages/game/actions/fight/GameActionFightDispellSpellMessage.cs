using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
    {
        public new const uint ProtocolId = 6176;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;

        public GameActionFightDispellSpellMessage(): base()
        {
        }

        public GameActionFightDispellSpellMessage(
            short actionId,
            double sourceId,
            double targetId,
            bool verboseCast,
            short spellId
        ): base(
            actionId,
            sourceId,
            targetId,
            verboseCast
        )
        {
            SpellId = spellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(SpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarShort();
        }
    }
}