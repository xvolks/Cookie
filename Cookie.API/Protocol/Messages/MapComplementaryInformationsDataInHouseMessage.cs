using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6130;

        public override ushort MessageID => ProtocolId;

        public HouseInformationsInside CurrentHouse { get; set; }
        public MapComplementaryInformationsDataInHouseMessage() { }

        public MapComplementaryInformationsDataInHouseMessage( HouseInformationsInside CurrentHouse ){
            this.CurrentHouse = CurrentHouse;
        }

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
