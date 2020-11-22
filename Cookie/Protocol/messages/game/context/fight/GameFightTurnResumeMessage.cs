using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnResumeMessage : GameFightTurnStartMessage
    {
        public new const uint ProtocolId = 6307;
        public override uint MessageID { get { return ProtocolId; } }

        public int RemainingTime = 0;

        public GameFightTurnResumeMessage(): base()
        {
        }

        public GameFightTurnResumeMessage(
            double id_,
            int waitTime,
            int remainingTime
        ): base(
            id_,
            waitTime
        )
        {
            RemainingTime = remainingTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(RemainingTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            RemainingTime = reader.ReadVarInt();
        }
    }
}