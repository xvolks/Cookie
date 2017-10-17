using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5715;

        public GuildFightLeaveRequestMessage(double taxCollectorId, ulong characterId)
        {
            TaxCollectorId = taxCollectorId;
            CharacterId = characterId;
        }

        public GuildFightLeaveRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TaxCollectorId { get; set; }
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TaxCollectorId);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadDouble();
            CharacterId = reader.ReadVarUhLong();
        }
    }
}