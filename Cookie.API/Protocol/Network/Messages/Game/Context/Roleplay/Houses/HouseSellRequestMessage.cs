using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseSellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5697;

        public HouseSellRequestMessage(int instanceId, ulong amount, bool forSale)
        {
            InstanceId = instanceId;
            Amount = amount;
            ForSale = forSale;
        }

        public HouseSellRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int InstanceId { get; set; }
        public ulong Amount { get; set; }
        public bool ForSale { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(InstanceId);
            writer.WriteVarUhLong(Amount);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(IDataReader reader)
        {
            InstanceId = reader.ReadInt();
            Amount = reader.ReadVarUhLong();
            ForSale = reader.ReadBoolean();
        }
    }
}