using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextKickMessage : NetworkMessage
    {
        public const uint ProtocolId = 6081;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;

        public GameContextKickMessage()
        {
        }

        public GameContextKickMessage(
            double targetId
        )
        {
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TargetId = reader.ReadDouble();
        }
    }
}