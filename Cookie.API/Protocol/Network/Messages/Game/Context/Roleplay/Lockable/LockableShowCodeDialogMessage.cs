using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    public class LockableShowCodeDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5740;

        public LockableShowCodeDialogMessage(bool changeOrUse, byte codeSize)
        {
            ChangeOrUse = changeOrUse;
            CodeSize = codeSize;
        }

        public LockableShowCodeDialogMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool ChangeOrUse { get; set; }
        public byte CodeSize { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ChangeOrUse);
            writer.WriteByte(CodeSize);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChangeOrUse = reader.ReadBoolean();
            CodeSize = reader.ReadByte();
        }
    }
}