using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage
    {
        public new const uint ProtocolId = 6496;
        public override uint MessageID { get { return ProtocolId; } }

        public GameCautiousMapMovementRequestMessage(): base()
        {
        }

        public GameCautiousMapMovementRequestMessage(
            List<short> keyMovements,
            double mapId
        ): base(
            keyMovements,
            mapId
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