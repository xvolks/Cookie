using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class OrnamentSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6370;

        public OrnamentSelectErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public OrnamentSelectErrorMessage()
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