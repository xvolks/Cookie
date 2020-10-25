using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint ProtocolId = 6130;
        public override uint MessageID { get { return ProtocolId; } }

        public HouseInformationsInside CurrentHouse;

        public MapComplementaryInformationsDataInHouseMessage(): base()
        {
        }

        public MapComplementaryInformationsDataInHouseMessage(
            short subAreaId,
            double mapId,
            List<HouseInformations> houses,
            List<GameRolePlayActorInformations> actors,
            List<InteractiveElement> interactiveElements,
            List<StatedElement> statedElements,
            List<MapObstacle> obstacles,
            List<FightCommonInformations> fights,
            bool hasAggressiveMonsters,
            FightStartingPositions fightStartPositions,
            HouseInformationsInside currentHouse
        ): base(
            subAreaId,
            mapId,
            houses,
            actors,
            interactiveElements,
            statedElements,
            obstacles,
            fights,
            hasAggressiveMonsters,
            fightStartPositions
        )
        {
            CurrentHouse = currentHouse;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            CurrentHouse.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CurrentHouse = new HouseInformationsInside();
            CurrentHouse.Deserialize(reader);
        }
    }
}