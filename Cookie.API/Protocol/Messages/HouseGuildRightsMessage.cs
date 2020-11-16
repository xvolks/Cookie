using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseGuildRightsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5703;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public uint Rights { get; set; }
        public HouseGuildRightsMessage() { }

        public HouseGuildRightsMessage( uint HouseId, int InstanceId, bool SecondHand, GuildInformations GuildInfo, uint Rights ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
            this.GuildInfo = GuildInfo;
            this.Rights = Rights;
        }

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
