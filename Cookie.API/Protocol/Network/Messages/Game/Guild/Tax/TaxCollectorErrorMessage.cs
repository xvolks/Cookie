using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5634;

        public TaxCollectorErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public TaxCollectorErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}