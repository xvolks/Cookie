using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareSubscribeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6666;

        public DareSubscribeRequestMessage(double dareId, bool subscribe)
        {
            DareId = dareId;
            Subscribe = subscribe;
        }

        public DareSubscribeRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }
        public bool Subscribe { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteBoolean(Subscribe);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Subscribe = reader.ReadBoolean();
        }
    }
}