using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LocalizedChatSmileyMessage : ChatSmileyMessage
    {
        public new const uint ProtocolId = 6185;
        public override uint MessageID { get { return ProtocolId; } }

        public short CellId = 0;

        public LocalizedChatSmileyMessage(): base()
        {
        }

        public LocalizedChatSmileyMessage(
            double entityId,
            short smileyId,
            int accountId,
            short cellId
        ): base(
            entityId,
            smileyId,
            accountId
        )
        {
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CellId = reader.ReadVarShort();
        }
    }
}