using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5715;
        public override uint MessageID { get { return ProtocolId; } }

        public double TaxCollectorId = 0;
        public long CharacterId = 0;

        public GuildFightLeaveRequestMessage()
        {
        }

        public GuildFightLeaveRequestMessage(
            double taxCollectorId,
            long characterId
        )
        {
            TaxCollectorId = taxCollectorId;
            CharacterId = characterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(TaxCollectorId);
            writer.WriteVarLong(CharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TaxCollectorId = reader.ReadDouble();
            CharacterId = reader.ReadVarLong();
        }
    }
}