using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.House
{
    public class HouseTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6726;

        public HouseTeleportRequestMessage(uint houseId, int houseInstanceId)
        {
            HouseId = houseId;
            HouseInstanceId = houseInstanceId;
        }

        public HouseTeleportRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int HouseInstanceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(HouseInstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            HouseInstanceId = reader.ReadInt();
        }
    }
}