using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6130;

        public MapComplementaryInformationsDataInHouseMessage(HouseInformationsInside currentHouse)
        {
            CurrentHouse = currentHouse;
        }

        public MapComplementaryInformationsDataInHouseMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public HouseInformationsInside CurrentHouse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            CurrentHouse.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CurrentHouse = new HouseInformationsInside();
            CurrentHouse.Deserialize(reader);
        }
    }
}