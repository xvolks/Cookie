using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class AccountLoggingKickedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6029;

        public AccountLoggingKickedMessage(ushort days, byte hours, byte minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public AccountLoggingKickedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort Days { get; set; }
        public byte Hours { get; set; }
        public byte Minutes { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Days);
            writer.WriteByte(Hours);
            writer.WriteByte(Minutes);
        }

        public override void Deserialize(IDataReader reader)
        {
            Days = reader.ReadVarUhShort();
            Hours = reader.ReadByte();
            Minutes = reader.ReadByte();
        }
    }
}