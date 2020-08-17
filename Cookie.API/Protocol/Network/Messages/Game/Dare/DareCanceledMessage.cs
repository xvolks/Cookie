using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareCanceledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6679;

        public DareCanceledMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareCanceledMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
        }
    }
}