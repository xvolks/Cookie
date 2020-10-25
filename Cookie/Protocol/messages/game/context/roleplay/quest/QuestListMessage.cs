using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5626;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> FinishedQuestsIds;
        public List<short> FinishedQuestsCounts;
        public List<QuestActiveInformations> ActiveQuests;
        public List<short> ReinitDoneQuestsIds;

        public QuestListMessage()
        {
        }

        public QuestListMessage(
            List<short> finishedQuestsIds,
            List<short> finishedQuestsCounts,
            List<QuestActiveInformations> activeQuests,
            List<short> reinitDoneQuestsIds
        )
        {
            FinishedQuestsIds = finishedQuestsIds;
            FinishedQuestsCounts = finishedQuestsCounts;
            ActiveQuests = activeQuests;
            ReinitDoneQuestsIds = reinitDoneQuestsIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)FinishedQuestsIds.Count());
            foreach (var current in FinishedQuestsIds)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)FinishedQuestsCounts.Count());
            foreach (var current in FinishedQuestsCounts)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)ActiveQuests.Count());
            foreach (var current in ActiveQuests)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)ReinitDoneQuestsIds.Count());
            foreach (var current in ReinitDoneQuestsIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFinishedQuestsIds = reader.ReadShort();
            FinishedQuestsIds = new List<short>();
            for (short i = 0; i < countFinishedQuestsIds; i++)
            {
                FinishedQuestsIds.Add(reader.ReadVarShort());
            }
            var countFinishedQuestsCounts = reader.ReadShort();
            FinishedQuestsCounts = new List<short>();
            for (short i = 0; i < countFinishedQuestsCounts; i++)
            {
                FinishedQuestsCounts.Add(reader.ReadVarShort());
            }
            var countActiveQuests = reader.ReadShort();
            ActiveQuests = new List<QuestActiveInformations>();
            for (short i = 0; i < countActiveQuests; i++)
            {
                var activeQueststypeId = reader.ReadShort();
                QuestActiveInformations type = new QuestActiveInformations();
                type.Deserialize(reader);
                ActiveQuests.Add(type);
            }
            var countReinitDoneQuestsIds = reader.ReadShort();
            ReinitDoneQuestsIds = new List<short>();
            for (short i = 0; i < countReinitDoneQuestsIds; i++)
            {
                ReinitDoneQuestsIds.Add(reader.ReadVarShort());
            }
        }
    }
}