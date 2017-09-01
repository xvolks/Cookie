using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class QuestListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5626;

        public QuestListMessage(List<ushort> finishedQuestsIds, List<ushort> finishedQuestsCounts,
            List<QuestActiveInformations> activeQuests, List<ushort> reinitDoneQuestsIds)
        {
            FinishedQuestsIds = finishedQuestsIds;
            FinishedQuestsCounts = finishedQuestsCounts;
            ActiveQuests = activeQuests;
            ReinitDoneQuestsIds = reinitDoneQuestsIds;
        }

        public QuestListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> FinishedQuestsIds { get; set; }
        public List<ushort> FinishedQuestsCounts { get; set; }
        public List<QuestActiveInformations> ActiveQuests { get; set; }
        public List<ushort> ReinitDoneQuestsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FinishedQuestsIds.Count);
            for (var finishedQuestsIdsIndex = 0;
                finishedQuestsIdsIndex < FinishedQuestsIds.Count;
                finishedQuestsIdsIndex++)
                writer.WriteVarUhShort(FinishedQuestsIds[finishedQuestsIdsIndex]);
            writer.WriteShort((short) FinishedQuestsCounts.Count);
            for (var finishedQuestsCountsIndex = 0;
                finishedQuestsCountsIndex < FinishedQuestsCounts.Count;
                finishedQuestsCountsIndex++)
                writer.WriteVarUhShort(FinishedQuestsCounts[finishedQuestsCountsIndex]);
            writer.WriteShort((short) ActiveQuests.Count);
            for (var activeQuestsIndex = 0; activeQuestsIndex < ActiveQuests.Count; activeQuestsIndex++)
            {
                var objectToSend = ActiveQuests[activeQuestsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) ReinitDoneQuestsIds.Count);
            for (var reinitDoneQuestsIdsIndex = 0;
                reinitDoneQuestsIdsIndex < ReinitDoneQuestsIds.Count;
                reinitDoneQuestsIdsIndex++)
                writer.WriteVarUhShort(ReinitDoneQuestsIds[reinitDoneQuestsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var finishedQuestsIdsCount = reader.ReadUShort();
            FinishedQuestsIds = new List<ushort>();
            for (var finishedQuestsIdsIndex = 0;
                finishedQuestsIdsIndex < finishedQuestsIdsCount;
                finishedQuestsIdsIndex++)
                FinishedQuestsIds.Add(reader.ReadVarUhShort());
            var finishedQuestsCountsCount = reader.ReadUShort();
            FinishedQuestsCounts = new List<ushort>();
            for (var finishedQuestsCountsIndex = 0;
                finishedQuestsCountsIndex < finishedQuestsCountsCount;
                finishedQuestsCountsIndex++)
                FinishedQuestsCounts.Add(reader.ReadVarUhShort());
            var activeQuestsCount = reader.ReadUShort();
            ActiveQuests = new List<QuestActiveInformations>();
            for (var activeQuestsIndex = 0; activeQuestsIndex < activeQuestsCount; activeQuestsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                ActiveQuests.Add(objectToAdd);
            }
            var reinitDoneQuestsIdsCount = reader.ReadUShort();
            ReinitDoneQuestsIds = new List<ushort>();
            for (var reinitDoneQuestsIdsIndex = 0;
                reinitDoneQuestsIdsIndex < reinitDoneQuestsIdsCount;
                reinitDoneQuestsIdsIndex++)
                ReinitDoneQuestsIds.Add(reader.ReadVarUhShort());
        }
    }
}