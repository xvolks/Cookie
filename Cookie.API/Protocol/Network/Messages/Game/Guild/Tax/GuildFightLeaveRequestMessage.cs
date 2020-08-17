using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5715;

        public GuildFightLeaveRequestMessage(int taxCollectorId, ulong characterId)
        {
            TaxCollectorId = taxCollectorId;
            CharacterId = characterId;
        }

        public GuildFightLeaveRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int TaxCollectorId { get; set; }
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TaxCollectorId);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadInt();
            CharacterId = reader.ReadVarUhLong();
        }
    }
}