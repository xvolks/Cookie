using Cookie.Network;

namespace Cookie.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Cookie.IO;
    using Cookie.Protocol.Network.Types.Game.Context.Fight;
    using Cookie.Protocol.Network.Types.Game.Context.Roleplay;
    using Cookie.Protocol.Network.Types.Game.House;
    using Cookie.Protocol.Network.Types.Game.Interactive;
    using System.Collections.Generic;

    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 226;

        public override uint MessageID => ProtocolId;

        private ushort m_subAreaId;

        public virtual ushort SubAreaId
        {
            get => m_subAreaId;
            set => m_subAreaId = value;
        }

        private int m_mapId;

        public virtual int MapId
        {
            get => m_mapId;
            set => m_mapId = value;
        }

        private List<HouseInformations> m_houses;

        public virtual List<HouseInformations> Houses
        {
            get => m_houses;
            set => m_houses = value;
        }

        private List<GameRolePlayActorInformations> m_actors;

        public virtual List<GameRolePlayActorInformations> Actors
        {
            get => m_actors;
            set => m_actors = value;
        }

        private List<InteractiveElement> m_interactiveElements;

        public virtual List<InteractiveElement> InteractiveElements
        {
            get => m_interactiveElements;
            set => m_interactiveElements = value;
        }

        private List<StatedElement> m_statedElements;

        public virtual List<StatedElement> StatedElements
        {
            get
            {
                return m_statedElements;
            }
            set
            {
                m_statedElements = value;
            }
        }

        private List<MapObstacle> m_obstacles;

        public virtual List<MapObstacle> Obstacles
        {
            get => m_obstacles;
            set => m_obstacles = value;
        }

        private List<FightCommonInformations> m_fights;

        public virtual List<FightCommonInformations> Fights
        {
            get => m_fights;
            set => m_fights = value;
        }

        private FightStartingPositions m_fightStartPositions;

        public virtual FightStartingPositions FightStartPositions
        {
            get => m_fightStartPositions;
            set => m_fightStartPositions = value;
        }

        private bool m_hasAggressiveMonsters;

        public virtual bool HasAggressiveMonsters
        {
            get => m_hasAggressiveMonsters;
            set => m_hasAggressiveMonsters = value;
        }

        public MapComplementaryInformationsDataMessage(List<HouseInformations> houses, List<GameRolePlayActorInformations> actors, List<InteractiveElement> interactiveElements, List<StatedElement> statedElements, List<MapObstacle> obstacles, List<FightCommonInformations> fights, FightStartingPositions fightStartPositions, ushort subAreaId, int mapId, bool hasAggressiveMonsters)
        {
            m_houses = houses;
            m_actors = actors;
            m_interactiveElements = interactiveElements;
            m_statedElements = statedElements;
            m_obstacles = obstacles;
            m_fights = fights;
            m_fightStartPositions = fightStartPositions;
            m_subAreaId = subAreaId;
            m_mapId = mapId;
            m_hasAggressiveMonsters = hasAggressiveMonsters;
        }

        public MapComplementaryInformationsDataMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteInt(m_mapId);
            writer.WriteShort(((short)(m_houses.Count)));
            int housesIndex;
            for (housesIndex = 0; (housesIndex < m_houses.Count); housesIndex = (housesIndex + 1))
            {
                HouseInformations objectToSend = m_houses[housesIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_actors.Count)));
            int actorsIndex;
            for (actorsIndex = 0; (actorsIndex < m_actors.Count); actorsIndex = (actorsIndex + 1))
            {
                GameRolePlayActorInformations objectToSend = m_actors[actorsIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_interactiveElements.Count)));
            int interactiveElementsIndex;
            for (interactiveElementsIndex = 0; (interactiveElementsIndex < m_interactiveElements.Count); interactiveElementsIndex = (interactiveElementsIndex + 1))
            {
                InteractiveElement objectToSend = m_interactiveElements[interactiveElementsIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_statedElements.Count)));
            int statedElementsIndex;
            for (statedElementsIndex = 0; (statedElementsIndex < m_statedElements.Count); statedElementsIndex = (statedElementsIndex + 1))
            {
                StatedElement objectToSend = m_statedElements[statedElementsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_obstacles.Count)));
            int obstaclesIndex;
            for (obstaclesIndex = 0; (obstaclesIndex < m_obstacles.Count); obstaclesIndex = (obstaclesIndex + 1))
            {
                MapObstacle objectToSend = m_obstacles[obstaclesIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_fights.Count)));
            int fightsIndex;
            for (fightsIndex = 0; (fightsIndex < m_fights.Count); fightsIndex = (fightsIndex + 1))
            {
                FightCommonInformations objectToSend = m_fights[fightsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteBoolean(m_hasAggressiveMonsters);
            m_fightStartPositions.Serialize(writer);   
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            m_subAreaId = reader.ReadVarUhShort();
            m_mapId = reader.ReadInt();
            int housesCount = reader.ReadUShort();
            int housesIndex;
            m_houses = new System.Collections.Generic.List<HouseInformations>();
            for (housesIndex = 0; (housesIndex < housesCount); housesIndex = (housesIndex + 1))
            {
                HouseInformations objectToAdd = ProtocolTypeManager.GetInstance<HouseInformations>((short)reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_houses.Add(objectToAdd);
            }
            int actorsCount = reader.ReadUShort();
            int actorsIndex;
            m_actors = new System.Collections.Generic.List<GameRolePlayActorInformations>();
            for (actorsIndex = 0; (actorsIndex < actorsCount); actorsIndex = (actorsIndex + 1))
            {
                GameRolePlayActorInformations objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>((short)reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_actors.Add(objectToAdd);
            }
            int interactiveElementsCount = reader.ReadUShort();
            int interactiveElementsIndex;
            m_interactiveElements = new System.Collections.Generic.List<InteractiveElement>();
            for (interactiveElementsIndex = 0; (interactiveElementsIndex < interactiveElementsCount); interactiveElementsIndex = (interactiveElementsIndex + 1))
            {
                InteractiveElement objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>((short)reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_interactiveElements.Add(objectToAdd);
            }
            int statedElementsCount = reader.ReadUShort();
            int statedElementsIndex;
            m_statedElements = new System.Collections.Generic.List<StatedElement>();
            for (statedElementsIndex = 0; (statedElementsIndex < statedElementsCount); statedElementsIndex = (statedElementsIndex + 1))
            {
                StatedElement objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                m_statedElements.Add(objectToAdd);
            }
            int obstaclesCount = reader.ReadUShort();
            int obstaclesIndex;
            m_obstacles = new System.Collections.Generic.List<MapObstacle>();
            for (obstaclesIndex = 0; (obstaclesIndex < obstaclesCount); obstaclesIndex = (obstaclesIndex + 1))
            {
                MapObstacle objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                m_obstacles.Add(objectToAdd);
            }
            int fightsCount = reader.ReadUShort();
            int fightsIndex;
            m_fights = new System.Collections.Generic.List<FightCommonInformations>();
            for (fightsIndex = 0; (fightsIndex < fightsCount); fightsIndex = (fightsIndex + 1))
            {
                FightCommonInformations objectToAdd = new FightCommonInformations();
                objectToAdd.Deserialize(reader);
                m_fights.Add(objectToAdd);
            }
            m_hasAggressiveMonsters = reader.ReadBoolean();
            m_fightStartPositions = new FightStartingPositions();
            m_fightStartPositions.Deserialize(reader);
        }
    }
}
