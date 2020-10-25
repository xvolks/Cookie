using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameCautiousMapMovementMessage : GameMapMovementMessage
    {
        public new const uint ProtocolId = 6497;
        public override uint MessageID { get { return ProtocolId; } }

        public GameCautiousMapMovementMessage(): base()
        {
        }

        public GameCautiousMapMovementMessage(
            List<short> keyMovements,
            short forcedDirection,
            double actorId
        ): base(
            keyMovements,
            forcedDirection,
            actorId
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}