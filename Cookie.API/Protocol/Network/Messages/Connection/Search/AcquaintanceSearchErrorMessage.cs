using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection.Search
{
    public class AcquaintanceSearchErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6143;

        public AcquaintanceSearchErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public AcquaintanceSearchErrorMessage()
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