using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnEndMessage : NetworkMessage
    {
        public const uint ProtocolId = 719;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;

        public GameFightTurnEndMessage()
        {
        }

        public GameFightTurnEndMessage(
            double id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
        }
    }
}