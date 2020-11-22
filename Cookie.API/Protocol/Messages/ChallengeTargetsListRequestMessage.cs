using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChallengeTargetsListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5614;

        public override ushort MessageID => ProtocolId;

        public ushort ChallengeId { get; set; }
        public ChallengeTargetsListRequestMessage() { }

        public ChallengeTargetsListRequestMessage( ushort ChallengeId ){
            this.ChallengeId = ChallengeId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
        }
    }
}
