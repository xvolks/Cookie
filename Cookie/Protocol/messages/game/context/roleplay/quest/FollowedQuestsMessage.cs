using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class FollowedQuestsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6717;
        public override uint MessageID { get { return ProtocolId; } }

        public List<QuestActiveDetailedInformations> Quests;

        public FollowedQuestsMessage()
        {
        }

        public FollowedQuestsMessage(
            List<QuestActiveDetailedInformations> quests
        )
        {
            Quests = quests;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Quests.Count());
            foreach (var current in Quests)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countQuests = reader.ReadShort();
            Quests = new List<QuestActiveDetailedInformations>();
            for (short i = 0; i < countQuests; i++)
            {
                QuestActiveDetailedInformations type = new QuestActiveDetailedInformations();
                type.Deserialize(reader);
                Quests.Add(type);
            }
        }
    }
}