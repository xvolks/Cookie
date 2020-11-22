using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FollowedQuestsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6717;

        public override ushort MessageID => ProtocolId;

        public List<QuestActiveDetailedInformations> Quests { get; set; }
        public FollowedQuestsMessage() { }

        public FollowedQuestsMessage( List<QuestActiveDetailedInformations> Quests ){
            this.Quests = Quests;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Quests.Count);
			foreach (var x in Quests)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var QuestsCount = reader.ReadShort();
            Quests = new List<QuestActiveDetailedInformations>();
            for (var i = 0; i < QuestsCount; i++)
            {
                var objectToAdd = new QuestActiveDetailedInformations();
                objectToAdd.Deserialize(reader);
                Quests.Add(objectToAdd);
            }
        }
    }
}
