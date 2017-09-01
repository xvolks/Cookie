namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildSpellUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5699;
        public override ushort MessageID => ProtocolId;
        public int SpellId { get; set; }

        public GuildSpellUpgradeRequestMessage(int spellId)
        {
            SpellId = spellId;
        }

        public GuildSpellUpgradeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
        }

    }
}
