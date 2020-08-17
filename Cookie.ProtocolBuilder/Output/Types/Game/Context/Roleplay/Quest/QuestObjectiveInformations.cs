namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest
{
    using System.Collections.Generic;
    using Utils.IO;

    public class QuestObjectiveInformations : NetworkType
    {
        public const ushort ProtocolId = 385;
        public override ushort TypeID => ProtocolId;
        public ushort ObjectiveId { get; set; }
        public bool ObjectiveStatus { get; set; }
        public List<string> DialogParams { get; set; }

        public QuestObjectiveInformations(ushort objectiveId, bool objectiveStatus, List<string> dialogParams)
        {
            ObjectiveId = objectiveId;
            ObjectiveStatus = objectiveStatus;
            DialogParams = dialogParams;
        }

        public QuestObjectiveInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectiveId);
            writer.WriteBoolean(ObjectiveStatus);
            writer.WriteShort((short)DialogParams.Count);
            for (var dialogParamsIndex = 0; dialogParamsIndex < DialogParams.Count; dialogParamsIndex++)
            {
                writer.WriteUTF(DialogParams[dialogParamsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectiveId = reader.ReadVarUhShort();
            ObjectiveStatus = reader.ReadBoolean();
            var dialogParamsCount = reader.ReadUShort();
            DialogParams = new List<string>();
            for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
            {
                DialogParams.Add(reader.ReadUTF());
            }
        }

    }
}
