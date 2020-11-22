using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5717;

        public override ushort MessageID => ProtocolId;

        public double TaxCollectorId { get; set; }
        public GuildFightJoinRequestMessage() { }

        public GuildFightJoinRequestMessage( double TaxCollectorId ){
            this.TaxCollectorId = TaxCollectorId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TaxCollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadDouble();
        }
    }
}
