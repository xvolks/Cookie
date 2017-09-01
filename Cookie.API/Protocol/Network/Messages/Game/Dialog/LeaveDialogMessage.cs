using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dialog
{
    public class LeaveDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5502;

        public LeaveDialogMessage(byte dialogType)
        {
            DialogType = dialogType;
        }

        public LeaveDialogMessage()
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