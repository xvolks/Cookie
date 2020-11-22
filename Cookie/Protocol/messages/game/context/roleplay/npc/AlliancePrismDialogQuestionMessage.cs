using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AlliancePrismDialogQuestionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6448;
        public override uint MessageID { get { return ProtocolId; } }

        public AlliancePrismDialogQuestionMessage()
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