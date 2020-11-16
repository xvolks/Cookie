using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 1005;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;
        public short CellId = 0;

        public GameActionFightCastRequestMessage()
        {
        }

        public GameActionFightCastRequestMessage(
            short spellId,
            short cellId
        )
        {
            SpellId = spellId;
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SpellId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadVarShort();
            CellId = reader.ReadShort();
        }
    }
}