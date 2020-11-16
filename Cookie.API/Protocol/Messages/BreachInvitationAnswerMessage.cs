using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachInvitationAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6795;

        public override ushort MessageID => ProtocolId;

        public bool Accept { get; set; }
        public BreachInvitationAnswerMessage() { }

        public BreachInvitationAnswerMessage( bool Accept ){
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Accept = reader.ReadBoolean();
        }
    }
}