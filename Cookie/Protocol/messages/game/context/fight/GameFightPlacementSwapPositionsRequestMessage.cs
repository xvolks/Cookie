using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
    {
        public new const uint ProtocolId = 6541;
        public override uint MessageID { get { return ProtocolId; } }

        public double RequestedId = 0;

        public GameFightPlacementSwapPositionsRequestMessage(): base()
        {
        }

        public GameFightPlacementSwapPositionsRequestMessage(
            short cellId,
            double requestedId
        ): base(
            cellId
        )
        {
            RequestedId = requestedId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(RequestedId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            RequestedId = reader.ReadDouble();
        }
    }
}