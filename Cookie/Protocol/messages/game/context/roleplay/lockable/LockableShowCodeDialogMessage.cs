using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableShowCodeDialogMessage : NetworkMessage
    {
        public const uint ProtocolId = 5740;
        public override uint MessageID { get { return ProtocolId; } }

        public bool ChangeOrUse = false;
        public byte CodeSize = 0;

        public LockableShowCodeDialogMessage()
        {
        }

        public LockableShowCodeDialogMessage(
            bool changeOrUse,
            byte codeSize
        )
        {
            ChangeOrUse = changeOrUse;
            CodeSize = codeSize;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(ChangeOrUse);
            writer.WriteByte(CodeSize);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ChangeOrUse = reader.ReadBoolean();
            CodeSize = reader.ReadByte();
        }
    }
}