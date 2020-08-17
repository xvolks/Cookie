namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.House;
    using Types.Game.House;
    using Types.Game.Context.Roleplay;
    using Types.Game.Interactive;
    using Types.Game.Interactive;
    using Types.Game.Interactive;
    using Types.Game.Context.Fight;
    using Types.Game.Context.Fight;
    using System.Collections.Generic;
    using Utils.IO;

    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6130;
        public override ushort MessageID => ProtocolId;
        public HouseInformationsInside CurrentHouse { get; set; }

        public MapComplementaryInformationsDataInHouseMessage(HouseInformationsInside currentHouse)
        {
            CurrentHouse = currentHouse;
        }

        public MapComplementaryInformationsDataInHouseMessage() { }

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
