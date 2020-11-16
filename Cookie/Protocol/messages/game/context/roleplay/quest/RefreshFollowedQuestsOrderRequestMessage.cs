using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6722;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Quests;

        public RefreshFollowedQuestsOrderRequestMessage()
        {
        }

        public RefreshFollowedQuestsOrderRequestMessage(
            List<short> quests
        )
        {
            Quests = quests;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Quests.Count());
            foreach (var current in Quests)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countQuests = reader.ReadShort();
            Quests = new List<short>();
            for (short i = 0; i < countQuests; i++)
            {
                Quests.Add(reader.ReadVarShort());
            }
        }
    }
}