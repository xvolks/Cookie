using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareCancelRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6680;

        public DareCancelRequestMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareCancelRequestMessage()
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