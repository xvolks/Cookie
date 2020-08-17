using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildHouseUpdateInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6181;

        public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
        {
            HousesInformations = housesInformations;
        }

        public GuildHouseUpdateInformationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public HouseInformationsForGuild HousesInformations { get; set; }

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