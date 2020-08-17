using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    public class BasicPingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 182;

        public BasicPingMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Quiet { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Quiet);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quiet = reader.ReadBoolean();
        }
    }
}