namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    using Utils.IO;

    public class SpellVariantActivationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6707;
        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }

        public SpellVariantActivationRequestMessage(ushort spellId)
        {
            SpellId = spellId;
        }

        public SpellVariantActivationRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
        }

    }
}
