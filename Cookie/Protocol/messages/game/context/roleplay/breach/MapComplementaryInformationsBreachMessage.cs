using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint ProtocolId = 6791;
        public override uint MessageID { get { return ProtocolId; } }

        public int Floor = 0;
        public byte Room = 0;
        public List<BreachBranch> Branches;

        public MapComplementaryInformationsBreachMessage(): base()
        {
        }

        public MapComplementaryInformationsBreachMessage(
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
            int floor,
            byte room,
            List<BreachBranch> branches
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
            Floor = floor;
            Room = room;
            Branches = branches;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Floor);
            writer.WriteByte(Room);
            writer.WriteShort((short)Branches.Count());
            foreach (var current in Branches)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Floor = reader.ReadVarInt();
            Room = reader.ReadByte();
            var countBranches = reader.ReadShort();
            Branches = new List<BreachBranch>();
            for (short i = 0; i < countBranches; i++)
            {
                BreachBranch type = new BreachBranch();
                type.Deserialize(reader);
                Branches.Add(type);
            }
        }
    }
}