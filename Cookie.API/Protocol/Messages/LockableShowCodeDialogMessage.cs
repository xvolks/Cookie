using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LockableShowCodeDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5740;

        public override ushort MessageID => ProtocolId;

        public bool ChangeOrUse { get; set; }
        public sbyte CodeSize { get; set; }
        public LockableShowCodeDialogMessage() { }

        public LockableShowCodeDialogMessage( bool ChangeOrUse, sbyte CodeSize ){
            this.ChangeOrUse = ChangeOrUse;
            this.CodeSize = CodeSize;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ChangeOrUse);
            writer.WriteSByte(CodeSize);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChangeOrUse = reader.ReadBoolean();
            CodeSize = reader.ReadSByte();
        }
    }
}
