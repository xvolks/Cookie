using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnStartMessage : NetworkMessage
    {
        public const uint ProtocolId = 714;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;
        public int WaitTime = 0;

        public GameFightTurnStartMessage()
        {
        }

        public GameFightTurnStartMessage(
            double id_,
            int waitTime
        )
        {
            Id_ = id_;
            WaitTime = waitTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
            writer.WriteVarInt(WaitTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
            WaitTime = reader.ReadVarInt();
        }
    }
}