using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildHousesInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5919;

        public override ushort MessageID => ProtocolId;

        public List<HouseInformationsForGuild> HousesInformations { get; set; }
        public GuildHousesInformationMessage() { }

        public GuildHousesInformationMessage( List<HouseInformationsForGuild> HousesInformations ){
            this.HousesInformations = HousesInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)HousesInformations.Count);
			foreach (var x in HousesInformations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var HousesInformationsCount = reader.ReadShort();
            HousesInformations = new List<HouseInformationsForGuild>();
            for (var i = 0; i < HousesInformationsCount; i++)
            {
                var objectToAdd = new HouseInformationsForGuild();
                objectToAdd.Deserialize(reader);
                HousesInformations.Add(objectToAdd);
            }
        }
    }
}
