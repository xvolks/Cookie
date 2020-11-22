using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildHouseUpdateInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6181;

        public override ushort MessageID => ProtocolId;

        public HouseInformationsForGuild HousesInformations { get; set; }
        public GuildHouseUpdateInformationMessage() { }

        public GuildHouseUpdateInformationMessage( HouseInformationsForGuild HousesInformations ){
            this.HousesInformations = HousesInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            HousesInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HousesInformations = new HouseInformationsForGuild();
            HousesInformations.Deserialize(reader);
        }
    }
}
