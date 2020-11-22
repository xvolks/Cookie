using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayNpcQuestFlag : NetworkType
    {
        public const ushort ProtocolId = 384;

        public override ushort TypeID => ProtocolId;

        public List<short> QuestsToValidId { get; set; }
        public List<short> QuestsToStartId { get; set; }
        public GameRolePlayNpcQuestFlag() { }

        public GameRolePlayNpcQuestFlag( List<short> QuestsToValidId, List<short> QuestsToStartId ){
            this.QuestsToValidId = QuestsToValidId;
            this.QuestsToStartId = QuestsToStartId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)QuestsToValidId.Count);
			foreach (var x in QuestsToValidId)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)QuestsToStartId.Count);
			foreach (var x in QuestsToStartId)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var QuestsToValidIdCount = reader.ReadShort();
            QuestsToValidId = new List<short>();
            for (var i = 0; i < QuestsToValidIdCount; i++)
            {
                QuestsToValidId.Add(reader.ReadVarShort());
            }
            var QuestsToStartIdCount = reader.ReadShort();
            QuestsToStartId = new List<short>();
            for (var i = 0; i < QuestsToStartIdCount; i++)
            {
                QuestsToStartId.Add(reader.ReadVarShort());
            }
        }
    }
}
