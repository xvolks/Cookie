using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public new const ushort ProtocolId = 382;

        public override ushort TypeID => ProtocolId;

        public ushort StepId { get; set; }
        public List<QuestObjectiveInformations> Objectives { get; set; }
        public QuestActiveDetailedInformations() { }

        public QuestActiveDetailedInformations( ushort StepId, List<QuestObjectiveInformations> Objectives ){
            this.StepId = StepId;
            this.Objectives = Objectives;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(StepId);
			writer.WriteShort((short)Objectives.Count);
			foreach (var x in Objectives)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StepId = reader.ReadVarUhShort();
            var ObjectivesCount = reader.ReadShort();
            Objectives = new List<QuestObjectiveInformations>();
            for (var i = 0; i < ObjectivesCount; i++)
            {
                QuestObjectiveInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Objectives.Add(objectToAdd);
            }
        }
    }
}
