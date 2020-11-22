using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5626;

        public override ushort MessageID => ProtocolId;

        public List<short> FinishedQuestsIds { get; set; }
        public List<short> FinishedQuestsCounts { get; set; }
        public List<QuestActiveInformations> ActiveQuests { get; set; }
        public List<short> ReinitDoneQuestsIds { get; set; }
        public QuestListMessage() { }

        public QuestListMessage( List<short> FinishedQuestsIds, List<short> FinishedQuestsCounts, List<QuestActiveInformations> ActiveQuests, List<short> ReinitDoneQuestsIds ){
            this.FinishedQuestsIds = FinishedQuestsIds;
            this.FinishedQuestsCounts = FinishedQuestsCounts;
            this.ActiveQuests = ActiveQuests;
            this.ReinitDoneQuestsIds = ReinitDoneQuestsIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)FinishedQuestsIds.Count);
			foreach (var x in FinishedQuestsIds)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)FinishedQuestsCounts.Count);
			foreach (var x in FinishedQuestsCounts)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)ActiveQuests.Count);
			foreach (var x in ActiveQuests)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)ReinitDoneQuestsIds.Count);
			foreach (var x in ReinitDoneQuestsIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FinishedQuestsIdsCount = reader.ReadShort();
            FinishedQuestsIds = new List<short>();
            for (var i = 0; i < FinishedQuestsIdsCount; i++)
            {
                FinishedQuestsIds.Add(reader.ReadVarShort());
            }
            var FinishedQuestsCountsCount = reader.ReadShort();
            FinishedQuestsCounts = new List<short>();
            for (var i = 0; i < FinishedQuestsCountsCount; i++)
            {
                FinishedQuestsCounts.Add(reader.ReadVarShort());
            }
            var ActiveQuestsCount = reader.ReadShort();
            ActiveQuests = new List<QuestActiveInformations>();
            for (var i = 0; i < ActiveQuestsCount; i++)
            {
                QuestActiveInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                ActiveQuests.Add(objectToAdd);
            }
            var ReinitDoneQuestsIdsCount = reader.ReadShort();
            ReinitDoneQuestsIds = new List<short>();
            for (var i = 0; i < ReinitDoneQuestsIdsCount; i++)
            {
                ReinitDoneQuestsIds.Add(reader.ReadVarShort());
            }
        }
    }
}
