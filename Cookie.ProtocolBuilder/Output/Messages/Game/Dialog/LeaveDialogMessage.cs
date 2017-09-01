namespace Cookie.API.Protocol.Network.Messages.Game.Dialog
{
    using Utils.IO;

    public class LeaveDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5502;
        public override ushort MessageID => ProtocolId;
        public byte DialogType { get; set; }

        public LeaveDialogMessage(byte dialogType)
        {
            DialogType = dialogType;
        }

        public LeaveDialogMessage() { }

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
