using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SymbioticObjectErrorMessage : ObjectErrorMessage
    {
        public new const ushort ProtocolId = 6526;

        public override ushort MessageID => ProtocolId;

        public sbyte ErrorCode { get; set; }
        public SymbioticObjectErrorMessage() { }

        public SymbioticObjectErrorMessage( sbyte ErrorCode ){
            this.ErrorCode = ErrorCode;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ErrorCode);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ErrorCode = reader.ReadSByte();
        }
    }
}
