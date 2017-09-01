using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    public class BasicPongMessage : NetworkMessage
    {
        public const ushort ProtocolId = 183;

        public BasicPongMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPongMessage()
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