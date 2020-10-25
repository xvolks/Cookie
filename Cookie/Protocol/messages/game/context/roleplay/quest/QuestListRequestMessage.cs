using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5623;
        public override uint MessageID { get { return ProtocolId; } }

        public QuestListRequestMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}