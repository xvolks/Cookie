using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class QuestObjectiveInformations : NetworkType
    {
        public const ushort ProtocolId = 385;

        public override ushort TypeID => ProtocolId;

        public ushort ObjectiveId { get; set; }
        public bool ObjectiveStatus { get; set; }
        public List<string> DialogParams { get; set; }
        public QuestObjectiveInformations() { }

        public QuestObjectiveInformations( ushort ObjectiveId, bool ObjectiveStatus, List<string> DialogParams ){
            this.ObjectiveId = ObjectiveId;
            this.ObjectiveStatus = ObjectiveStatus;
            this.DialogParams = DialogParams;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectiveId);
            writer.WriteBoolean(ObjectiveStatus);
			writer.WriteShort((short)DialogParams.Count);
			foreach (var x in DialogParams)
			{
				writer.WriteUTF(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectiveId = reader.ReadVarUhShort();
            ObjectiveStatus = reader.ReadBoolean();
            var DialogParamsCount = reader.ReadShort();
            DialogParams = new List<string>();
            for (var i = 0; i < DialogParamsCount; i++)
            {
                DialogParams.Add(reader.ReadUTF());
            }
        }
    }
}
