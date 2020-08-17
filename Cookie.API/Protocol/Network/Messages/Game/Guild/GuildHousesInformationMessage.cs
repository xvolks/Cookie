using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildHousesInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5919;

        public GuildHousesInformationMessage(List<HouseInformationsForGuild> housesInformations)
        {
            HousesInformations = housesInformations;
        }

        public GuildHousesInformationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<HouseInformationsForGuild> HousesInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) HousesInformations.Count);
            for (var housesInformationsIndex = 0;
                housesInformationsIndex < HousesInformations.Count;
                housesInformationsIndex++)
            {
                var objectToSend = HousesInformations[housesInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var housesInformationsCount = reader.ReadUShort();
            HousesInformations = new List<HouseInformationsForGuild>();
            for (var housesInformationsIndex = 0;
                housesInformationsIndex < housesInformationsCount;
                housesInformationsIndex++)
            {
                var objectToAdd = new HouseInformationsForGuild();
                objectToAdd.Deserialize(reader);
                HousesInformations.Add(objectToAdd);
            }
        }
    }
}