namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1005;
        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }
        public short CellId { get; set; }

        public GameActionFightCastRequestMessage(ushort spellId, short cellId)
        {
            SpellId = spellId;
            CellId = cellId;
        }

        public GameActionFightCastRequestMessage() { }

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
