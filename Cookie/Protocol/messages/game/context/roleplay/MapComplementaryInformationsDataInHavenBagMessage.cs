using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint ProtocolId = 6622;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations OwnerInformations;
        public byte Theme = 0;
        public byte RoomId = 0;
        public byte MaxRoomId = 0;

        public MapComplementaryInformationsDataInHavenBagMessage(): base()
        {
        }

        public MapComplementaryInformationsDataInHavenBagMessage(
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
            CharacterMinimalInformations ownerInformations,
            byte theme,
            byte roomId,
            byte maxRoomId
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
            OwnerInformations = ownerInformations;
            Theme = theme;
            RoomId = roomId;
            MaxRoomId = maxRoomId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            OwnerInformations.Serialize(writer);
            writer.WriteByte(Theme);
            writer.WriteByte(RoomId);
            writer.WriteByte(MaxRoomId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            OwnerInformations = new CharacterMinimalInformations();
            OwnerInformations.Deserialize(reader);
            Theme = reader.ReadByte();
            RoomId = reader.ReadByte();
            MaxRoomId = reader.ReadByte();
        }
    }
}