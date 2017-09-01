using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceGuildLeavingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6399;

        public AllianceGuildLeavingMessage(bool kicked, uint guildId)
        {
            Kicked = kicked;
            GuildId = guildId;
        }

        public AllianceGuildLeavingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Kicked { get; set; }
        public uint GuildId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarUhInt(GuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Kicked = reader.ReadBoolean();
            GuildId = reader.ReadVarUhInt();
        }
    }
}