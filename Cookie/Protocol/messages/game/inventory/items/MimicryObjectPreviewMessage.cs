using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MimicryObjectPreviewMessage : NetworkMessage
    {
        public const uint ProtocolId = 6458;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItem Result;

        public MimicryObjectPreviewMessage()
        {
        }

        public MimicryObjectPreviewMessage(
            ObjectItem result
        )
        {
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Result.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Result = new ObjectItem();
            Result.Deserialize(reader);
        }
    }
}