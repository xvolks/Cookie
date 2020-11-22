using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayFreeSoulRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 745;
        public override uint MessageID { get { return ProtocolId; } }

        public GameRolePlayFreeSoulRequestMessage()
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