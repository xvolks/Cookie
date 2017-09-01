using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeOkMultiCraftMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5768;

        public ExchangeOkMultiCraftMessage(ulong initiatorId, ulong otherId, sbyte role)
        {
            InitiatorId = initiatorId;
            OtherId = otherId;
            Role = role;
        }

        public ExchangeOkMultiCraftMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong InitiatorId { get; set; }
        public ulong OtherId { get; set; }
        public sbyte Role { get; set; }

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