using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SymbioticObjectErrorMessage : ObjectErrorMessage
    {
        public new const uint ProtocolId = 6526;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ErrorCode = 0;

        public SymbioticObjectErrorMessage(): base()
        {
        }

        public SymbioticObjectErrorMessage(
            byte reason,
            byte errorCode
        ): base(
            reason
        )
        {
            ErrorCode = errorCode;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(ErrorCode);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ErrorCode = reader.ReadByte();
        }
    }
}