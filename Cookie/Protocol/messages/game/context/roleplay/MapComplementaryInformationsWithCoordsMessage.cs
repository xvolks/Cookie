using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint ProtocolId = 6268;
        public override uint MessageID { get { return ProtocolId; } }

        public short WorldX = 0;
        public short WorldY = 0;

        public MapComplementaryInformationsWithCoordsMessage(): base()
        {
        }

        public MapComplementaryInformationsWithCoordsMessage(
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
            short worldX,
            short worldY
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
            WorldX = worldX;
            WorldY = worldY;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}