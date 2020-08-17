using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildSpellUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5699;

        public GuildSpellUpgradeRequestMessage(int spellId)
        {
            SpellId = spellId;
        }

        public GuildSpellUpgradeRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int SpellId { get; set; }

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