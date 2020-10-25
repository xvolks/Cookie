using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const uint ProtocolId = 6461;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Preview = false;

        public MimicryObjectErrorMessage(): base()
        {
        }

        public MimicryObjectErrorMessage(
            byte reason,
            byte errorCode,
            bool preview
        ): base(
            reason,
            errorCode
        )
        {
            Preview = preview;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Preview = reader.ReadBoolean();
        }
    }
}