using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameContextKickMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6081;

        public GameContextKickMessage(double targetId)
        {
            TargetId = targetId;
        }

        public GameContextKickMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadDouble();
        }
    }
}