using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeOkMultiCraftMessage : NetworkMessage
    {
        public const uint ProtocolId = 5768;
        public override uint MessageID { get { return ProtocolId; } }

        public long InitiatorId = 0;
        public long OtherId = 0;
        public byte Role = 0;

        public ExchangeOkMultiCraftMessage()
        {
        }

        public ExchangeOkMultiCraftMessage(
            long initiatorId,
            long otherId,
            byte role
        )
        {
            InitiatorId = initiatorId;
            OtherId = otherId;
            Role = role;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(InitiatorId);
            writer.WriteVarLong(OtherId);
            writer.WriteByte(Role);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InitiatorId = reader.ReadVarLong();
            OtherId = reader.ReadVarLong();
            Role = reader.ReadByte();
        }
    }
}