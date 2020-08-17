namespace Cookie.API.Protocol.Network.Messages.Game.Dialog
{
    using Utils.IO;

    public class PauseDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6012;
        public override ushort MessageID => ProtocolId;
        public byte DialogType { get; set; }

        public PauseDialogMessage(byte dialogType)
        {
            DialogType = dialogType;
        }

        public PauseDialogMessage() { }

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
