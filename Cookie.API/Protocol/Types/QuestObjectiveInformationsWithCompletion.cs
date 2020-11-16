using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
    {
        public new const ushort ProtocolId = 386;

        public override ushort TypeID => ProtocolId;

        public ushort CurCompletion { get; set; }
        public ushort MaxCompletion { get; set; }
        public QuestObjectiveInformationsWithCompletion() { }

        public QuestObjectiveInformationsWithCompletion( ushort CurCompletion, ushort MaxCompletion ){
            this.CurCompletion = CurCompletion;
            this.MaxCompletion = MaxCompletion;
        }

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
