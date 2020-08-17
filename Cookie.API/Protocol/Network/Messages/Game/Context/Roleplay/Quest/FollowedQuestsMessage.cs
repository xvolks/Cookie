using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class FollowedQuestsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6717;

        public FollowedQuestsMessage(List<QuestActiveDetailedInformations> quests)
        {
            Quests = quests;
        }

        public FollowedQuestsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<QuestActiveDetailedInformations> Quests { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Quests.Count);
            for (var questsIndex = 0; questsIndex < Quests.Count; questsIndex++)
            {
                var objectToSend = Quests[questsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var questsCount = reader.ReadUShort();
            Quests = new List<QuestActiveDetailedInformations>();
            for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
            {
                var objectToAdd = new QuestActiveDetailedInformations();
                objectToAdd.Deserialize(reader);
                Quests.Add(objectToAdd);
            }
        }
    }
}