using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AcquaintanceAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6818;

        public override ushort MessageID => ProtocolId;

        public AcquaintanceInformation AcquaintanceAdded { get; set; }
        public AcquaintanceAddedMessage() { }

        public AcquaintanceAddedMessage( AcquaintanceInformation AcquaintanceAdded ){
            this.AcquaintanceAdded = AcquaintanceAdded;
        }

        public override void Serialize(IDataWriter writer)
        {
            AcquaintanceAdded.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AcquaintanceAdded = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            AcquaintanceAdded.Deserialize(reader);
        }
    }
}
