using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsAnomalyMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint ProtocolId = 6828;
        public override uint MessageID { get { return ProtocolId; } }

        public short Level = 0;
        public long ClosingTime = 0;

        public MapComplementaryInformationsAnomalyMessage(): base()
        {
        }

        public MapComplementaryInformationsAnomalyMessage(
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
            short level,
            long closingTime
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
            Level = level;
            ClosingTime = closingTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Level);
            writer.WriteVarLong(ClosingTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarShort();
            ClosingTime = reader.ReadVarLong();
        }
    }
}