using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6722;

        public override ushort MessageID => ProtocolId;

        public List<short> Quests { get; set; }
        public RefreshFollowedQuestsOrderRequestMessage() { }

        public RefreshFollowedQuestsOrderRequestMessage( List<short> Quests ){
            this.Quests = Quests;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Quests.Count);
			foreach (var x in Quests)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var QuestsCount = reader.ReadShort();
            Quests = new List<short>();
            for (var i = 0; i < QuestsCount; i++)
            {
                Quests.Add(reader.ReadVarShort());
            }
        }
    }
}
