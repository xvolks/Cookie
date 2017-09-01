using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    public class MoodSmileyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6196;

        public MoodSmileyResultMessage(byte resultCode, ushort smileyId)
        {
            ResultCode = resultCode;
            SmileyId = smileyId;
        }

        public MoodSmileyResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte ResultCode { get; set; }
        public ushort SmileyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ResultCode);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ResultCode = reader.ReadByte();
            SmileyId = reader.ReadVarUhShort();
        }
    }
}