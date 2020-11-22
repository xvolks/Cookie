using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6391;

        public override ushort MessageID => ProtocolId;

        public sbyte Result { get; set; }
        public AllianceCreationResultMessage() { }

        public AllianceCreationResultMessage( sbyte Result ){
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
        }
    }
}
