using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses.Guild
{
    public class HouseGuildShareRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5704;

        public HouseGuildShareRequestMessage(uint houseId, int instanceId, bool enable, uint rights)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            Enable = enable;
            Rights = rights;
        }

        public HouseGuildShareRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool Enable { get; set; }
        public uint Rights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(Enable);
            writer.WriteVarUhInt(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            Enable = reader.ReadBoolean();
            Rights = reader.ReadVarUhInt();
        }
    }
}