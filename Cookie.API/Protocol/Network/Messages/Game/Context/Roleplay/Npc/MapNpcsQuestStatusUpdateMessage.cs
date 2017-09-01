using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5642;

        public MapNpcsQuestStatusUpdateMessage(int mapId, List<int> npcsIdsWithQuest,
            List<GameRolePlayNpcQuestFlag> questFlags, List<int> npcsIdsWithoutQuest)
        {
            MapId = mapId;
            NpcsIdsWithQuest = npcsIdsWithQuest;
            QuestFlags = questFlags;
            NpcsIdsWithoutQuest = npcsIdsWithoutQuest;
        }

        public MapNpcsQuestStatusUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }
        public List<int> NpcsIdsWithQuest { get; set; }
        public List<GameRolePlayNpcQuestFlag> QuestFlags { get; set; }
        public List<int> NpcsIdsWithoutQuest { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
            writer.WriteShort((short) NpcsIdsWithQuest.Count);
            for (var npcsIdsWithQuestIndex = 0; npcsIdsWithQuestIndex < NpcsIdsWithQuest.Count; npcsIdsWithQuestIndex++)
                writer.WriteInt(NpcsIdsWithQuest[npcsIdsWithQuestIndex]);
            writer.WriteShort((short) QuestFlags.Count);
            for (var questFlagsIndex = 0; questFlagsIndex < QuestFlags.Count; questFlagsIndex++)
            {
                var objectToSend = QuestFlags[questFlagsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) NpcsIdsWithoutQuest.Count);
            for (var npcsIdsWithoutQuestIndex = 0;
                npcsIdsWithoutQuestIndex < NpcsIdsWithoutQuest.Count;
                npcsIdsWithoutQuestIndex++)
                writer.WriteInt(NpcsIdsWithoutQuest[npcsIdsWithoutQuestIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
            var npcsIdsWithQuestCount = reader.ReadUShort();
            NpcsIdsWithQuest = new List<int>();
            for (var npcsIdsWithQuestIndex = 0; npcsIdsWithQuestIndex < npcsIdsWithQuestCount; npcsIdsWithQuestIndex++)
                NpcsIdsWithQuest.Add(reader.ReadInt());
            var questFlagsCount = reader.ReadUShort();
            QuestFlags = new List<GameRolePlayNpcQuestFlag>();
            for (var questFlagsIndex = 0; questFlagsIndex < questFlagsCount; questFlagsIndex++)
            {
                var objectToAdd = new GameRolePlayNpcQuestFlag();
                objectToAdd.Deserialize(reader);
                QuestFlags.Add(objectToAdd);
            }
            var npcsIdsWithoutQuestCount = reader.ReadUShort();
            NpcsIdsWithoutQuest = new List<int>();
            for (var npcsIdsWithoutQuestIndex = 0;
                npcsIdsWithoutQuestIndex < npcsIdsWithoutQuestCount;
                npcsIdsWithoutQuestIndex++)
                NpcsIdsWithoutQuest.Add(reader.ReadInt());
        }
    }
}