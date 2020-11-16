using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5715;

        public override ushort MessageID => ProtocolId;

        public double TaxCollectorId { get; set; }
        public ulong CharacterId { get; set; }
        public GuildFightLeaveRequestMessage() { }

        public GuildFightLeaveRequestMessage( double TaxCollectorId, ulong CharacterId ){
            this.TaxCollectorId = TaxCollectorId;
            this.CharacterId = CharacterId;
        }

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
