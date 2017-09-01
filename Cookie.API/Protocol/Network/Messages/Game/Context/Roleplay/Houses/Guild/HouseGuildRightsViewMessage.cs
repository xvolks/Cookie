using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses.Guild
{
    public class HouseGuildRightsViewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5700;

        public HouseGuildRightsViewMessage(uint houseId, int instanceId)
        {
            HouseId = houseId;
            InstanceId = instanceId;
        }

        public HouseGuildRightsViewMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
        }
    }
}