using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        public const uint ProtocolId = 6132;
        public override uint MessageID { get { return ProtocolId; } }

        public int SpellLevelId = 0;

        public GameActionFightNoSpellCastMessage()
        {
        }

        public GameActionFightNoSpellCastMessage(
            int spellLevelId
        )
        {
            SpellLevelId = spellLevelId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(SpellLevelId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellLevelId = reader.ReadVarInt();
        }
    }
}