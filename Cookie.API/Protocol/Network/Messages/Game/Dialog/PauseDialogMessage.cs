using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dialog
{
    public class PauseDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6012;

        public PauseDialogMessage(byte dialogType)
        {
            DialogType = dialogType;
        }

        public PauseDialogMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte DialogType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(DialogType);
        }

        public override void Deserialize(IDataReader reader)
        {
            DialogType = reader.ReadByte();
        }
    }
}