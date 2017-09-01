namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.House;
    using Utils.IO;

    public class GuildHouseUpdateInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6181;
        public override ushort MessageID => ProtocolId;
        public HouseInformationsForGuild HousesInformations { get; set; }

        public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
        {
            HousesInformations = housesInformations;
        }

        public GuildHouseUpdateInformationMessage() { }

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
