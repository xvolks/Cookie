using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildHousesInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 5919;
        public override uint MessageID { get { return ProtocolId; } }

        public List<HouseInformationsForGuild> HousesInformations;

        public GuildHousesInformationMessage()
        {
        }

        public GuildHousesInformationMessage(
            List<HouseInformationsForGuild> housesInformations
        )
        {
            HousesInformations = housesInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)HousesInformations.Count());
            foreach (var current in HousesInformations)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countHousesInformations = reader.ReadShort();
            HousesInformations = new List<HouseInformationsForGuild>();
            for (short i = 0; i < countHousesInformations; i++)
            {
                HouseInformationsForGuild type = new HouseInformationsForGuild();
                type.Deserialize(reader);
                HousesInformations.Add(type);
            }
        }
    }
}