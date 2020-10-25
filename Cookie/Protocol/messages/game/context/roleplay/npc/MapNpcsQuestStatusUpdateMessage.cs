using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5642;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public List<int> NpcsIdsWithQuest;
        public List<GameRolePlayNpcQuestFlag> QuestFlags;
        public List<int> NpcsIdsWithoutQuest;

        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public MapNpcsQuestStatusUpdateMessage(
            double mapId,
            List<int> npcsIdsWithQuest,
            List<GameRolePlayNpcQuestFlag> questFlags,
            List<int> npcsIdsWithoutQuest
        )
        {
            MapId = mapId;
            NpcsIdsWithQuest = npcsIdsWithQuest;
            QuestFlags = questFlags;
            NpcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteShort((short)NpcsIdsWithQuest.Count());
            foreach (var current in NpcsIdsWithQuest)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort((short)QuestFlags.Count());
            foreach (var current in QuestFlags)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)NpcsIdsWithoutQuest.Count());
            foreach (var current in NpcsIdsWithoutQuest)
            {
                writer.WriteInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            var countNpcsIdsWithQuest = reader.ReadShort();
            NpcsIdsWithQuest = new List<int>();
            for (short i = 0; i < countNpcsIdsWithQuest; i++)
            {
                NpcsIdsWithQuest.Add(reader.ReadInt());
            }
            var countQuestFlags = reader.ReadShort();
            QuestFlags = new List<GameRolePlayNpcQuestFlag>();
            for (short i = 0; i < countQuestFlags; i++)
            {
                GameRolePlayNpcQuestFlag type = new GameRolePlayNpcQuestFlag();
                type.Deserialize(reader);
                QuestFlags.Add(type);
            }
            var countNpcsIdsWithoutQuest = reader.ReadShort();
            NpcsIdsWithoutQuest = new List<int>();
            for (short i = 0; i < countNpcsIdsWithoutQuest; i++)
            {
                NpcsIdsWithoutQuest.Add(reader.ReadInt());
            }
        }
    }
}