namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
    {
        public new const ushort ProtocolId = 6176;
        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }

        public GameActionFightDispellSpellMessage(ushort spellId)
        {
            SpellId = spellId;
        }

        public GameActionFightDispellSpellMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUhShort();
        }

    }
}
