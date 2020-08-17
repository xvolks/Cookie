namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest
{
    using System.Collections.Generic;
    using Utils.IO;

    public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
    {
        public new const ushort ProtocolId = 386;
        public override ushort TypeID => ProtocolId;
        public ushort CurCompletion { get; set; }
        public ushort MaxCompletion { get; set; }

        public QuestObjectiveInformationsWithCompletion(ushort curCompletion, ushort maxCompletion)
        {
            CurCompletion = curCompletion;
            MaxCompletion = maxCompletion;
        }

        public QuestObjectiveInformationsWithCompletion() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CurCompletion);
            writer.WriteVarUhShort(MaxCompletion);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CurCompletion = reader.ReadVarUhShort();
            MaxCompletion = reader.ReadVarUhShort();
        }

    }
}
