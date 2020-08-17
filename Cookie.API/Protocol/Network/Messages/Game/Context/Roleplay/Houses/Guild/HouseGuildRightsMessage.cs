using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses.Guild
{
    public class HouseGuildRightsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5703;

        public HouseGuildRightsMessage(uint houseId, int instanceId, bool secondHand, GuildInformations guildInfo,
            uint rights)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            GuildInfo = guildInfo;
            Rights = rights;
        }

        public HouseGuildRightsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public uint Rights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            GuildInfo.Serialize(writer);
            writer.WriteVarUhInt(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            Rights = reader.ReadVarUhInt();
        }
    }
}