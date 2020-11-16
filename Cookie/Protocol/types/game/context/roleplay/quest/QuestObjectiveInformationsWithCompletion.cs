using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
    {
        public new const short ProtocolId = 386;
        public override short TypeId { get { return ProtocolId; } }

        public short CurCompletion = 0;
        public short MaxCompletion = 0;

        public QuestObjectiveInformationsWithCompletion(): base()
        {
        }

        public QuestObjectiveInformationsWithCompletion(
            short objectiveId,
            bool objectiveStatus,
            List<string> dialogParams,
            short curCompletion,
            short maxCompletion
        ): base(
            objectiveId,
            objectiveStatus,
            dialogParams
        )
        {
            CurCompletion = curCompletion;
            MaxCompletion = maxCompletion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(CurCompletion);
            writer.WriteVarShort(MaxCompletion);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CurCompletion = reader.ReadVarShort();
            MaxCompletion = reader.ReadVarShort();
        }
    }
}