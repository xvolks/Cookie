using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5717;
        public override uint MessageID { get { return ProtocolId; } }

        public double TaxCollectorId = 0;

        public GuildFightJoinRequestMessage()
        {
        }

        public GuildFightJoinRequestMessage(
            double taxCollectorId
        )
        {
            TaxCollectorId = taxCollectorId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(TaxCollectorId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TaxCollectorId = reader.ReadDouble();
        }
    }
}