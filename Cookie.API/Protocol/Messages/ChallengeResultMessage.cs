using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChallengeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6019;

        public override ushort MessageID => ProtocolId;

        public ushort ChallengeId { get; set; }
        public bool Success { get; set; }
        public ChallengeResultMessage() { }

        public ChallengeResultMessage( ushort ChallengeId, bool Success ){
            this.ChallengeId = ChallengeId;
            this.Success = Success;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
            Success = reader.ReadBoolean();
        }
    }
}
