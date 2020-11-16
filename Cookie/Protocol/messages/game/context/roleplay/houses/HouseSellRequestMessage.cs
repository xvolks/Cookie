using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseSellRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5697;
        public override uint MessageID { get { return ProtocolId; } }

        public int InstanceId = 0;
        public long Amount = 0;
        public bool ForSale = false;

        public HouseSellRequestMessage()
        {
        }

        public HouseSellRequestMessage(
            int instanceId,
            long amount,
            bool forSale
        )
        {
            InstanceId = instanceId;
            Amount = amount;
            ForSale = forSale;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(InstanceId);
            writer.WriteVarLong(Amount);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InstanceId = reader.ReadInt();
            Amount = reader.ReadVarLong();
            ForSale = reader.ReadBoolean();
        }
    }
}