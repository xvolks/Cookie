using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitleSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6373;

        public TitleSelectErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public TitleSelectErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}