using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectUseOnCellMessage : ObjectUseMessage
    {
        public new const uint ProtocolId = 3013;
        public override uint MessageID { get { return ProtocolId; } }

        public short Cells = 0;

        public ObjectUseOnCellMessage(): base()
        {
        }

        public ObjectUseOnCellMessage(
            int objectUID,
            short cells
        ): base(
            objectUID
        )
        {
            Cells = cells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Cells);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Cells = reader.ReadVarShort();
        }
    }
}