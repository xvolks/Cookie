using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1005;

        public GameActionFightCastRequestMessage(ushort spellId, short cellId)
        {
            SpellId = spellId;
            CellId = cellId;
        }

        public GameActionFightCastRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }
        public short CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            CellId = reader.ReadShort();
        }
    }
}