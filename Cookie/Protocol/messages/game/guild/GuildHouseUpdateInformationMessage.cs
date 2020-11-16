using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildHouseUpdateInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6181;
        public override uint MessageID { get { return ProtocolId; } }

        public HouseInformationsForGuild HousesInformations;

        public GuildHouseUpdateInformationMessage()
        {
        }

        public GuildHouseUpdateInformationMessage(
            HouseInformationsForGuild housesInformations
        )
        {
            HousesInformations = housesInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            HousesInformations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HousesInformations = new HouseInformationsForGuild();
            HousesInformations.Deserialize(reader);
        }
    }
}