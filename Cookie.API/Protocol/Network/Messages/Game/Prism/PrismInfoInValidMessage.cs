using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismInfoInValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5859;

        public PrismInfoInValidMessage(byte reason)
        {
            Reason = reason;
        }

        public PrismInfoInValidMessage()
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