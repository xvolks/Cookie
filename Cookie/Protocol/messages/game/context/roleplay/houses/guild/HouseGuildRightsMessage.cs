using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseGuildRightsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5703;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;
        public bool SecondHand = false;
        public GuildInformations GuildInfo;
        public int Rights = 0;

        public HouseGuildRightsMessage()
        {
        }

        public HouseGuildRightsMessage(
            int houseId,
            int instanceId,
            bool secondHand,
            GuildInformations guildInfo,
            int rights
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            GuildInfo = guildInfo;
            Rights = rights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            GuildInfo.Serialize(writer);
            writer.WriteVarInt(Rights);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            Rights = reader.ReadVarInt();
        }
    }
}