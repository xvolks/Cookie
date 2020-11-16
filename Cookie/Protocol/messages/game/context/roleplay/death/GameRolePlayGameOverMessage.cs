using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayGameOverMessage : NetworkMessage
    {
        public const uint ProtocolId = 746;
        public override uint MessageID { get { return ProtocolId; } }

        public GameRolePlayGameOverMessage()
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