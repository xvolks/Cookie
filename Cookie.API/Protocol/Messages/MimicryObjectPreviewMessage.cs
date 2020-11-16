using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MimicryObjectPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6458;

        public override ushort MessageID => ProtocolId;

        public ObjectItem Result { get; set; }
        public MimicryObjectPreviewMessage() { }

        public MimicryObjectPreviewMessage( ObjectItem Result ){
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            Result.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = new ObjectItem();
            Result.Deserialize(reader);
        }
    }
}
