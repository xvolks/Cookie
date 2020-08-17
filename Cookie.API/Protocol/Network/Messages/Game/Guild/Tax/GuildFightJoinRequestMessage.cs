using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5717;

        public GuildFightJoinRequestMessage(int taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public GuildFightJoinRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int TaxCollectorId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TaxCollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadInt();
        }
    }
}