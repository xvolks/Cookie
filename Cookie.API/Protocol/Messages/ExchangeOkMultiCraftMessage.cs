using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeOkMultiCraftMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5768;

        public override ushort MessageID => ProtocolId;

        public ulong InitiatorId { get; set; }
        public ulong OtherId { get; set; }
        public sbyte Role { get; set; }
        public ExchangeOkMultiCraftMessage() { }

        public ExchangeOkMultiCraftMessage( ulong InitiatorId, ulong OtherId, sbyte Role ){
            this.InitiatorId = InitiatorId;
            this.OtherId = OtherId;
            this.Role = Role;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(InitiatorId);
            writer.WriteVarUhLong(OtherId);
            writer.WriteSByte(Role);
        }

        public override void Deserialize(IDataReader reader)
        {
            InitiatorId = reader.ReadVarUhLong();
            OtherId = reader.ReadVarUhLong();
            Role = reader.ReadSByte();
        }
    }
}
