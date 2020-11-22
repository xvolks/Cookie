using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayTaxCollectorFightRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5954;
        public override uint MessageID { get { return ProtocolId; } }

        public GameRolePlayTaxCollectorFightRequestMessage()
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