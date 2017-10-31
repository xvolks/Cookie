namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    using Utils.IO;

    public class SpellModifySuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6654;
        public override ushort MessageID => ProtocolId;
        public int SpellId { get; set; }
        public short SpellLevel { get; set; }

        public SpellModifySuccessMessage(int spellId, short spellLevel)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public SpellModifySuccessMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
            SpellLevel = reader.ReadShort();
        }

    }
}
