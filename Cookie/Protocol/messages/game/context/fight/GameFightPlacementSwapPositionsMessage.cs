using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6544;
        public override uint MessageID { get { return ProtocolId; } }

        public List<IdentifiedEntityDispositionInformations> Dispositions;

        public GameFightPlacementSwapPositionsMessage()
        {
        }

        public GameFightPlacementSwapPositionsMessage(
            List<IdentifiedEntityDispositionInformations> dispositions
        )
        {
            Dispositions = dispositions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            foreach (var current in Dispositions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Dispositions = new List<IdentifiedEntityDispositionInformations>();
            for (int i = 0; i < 2; i++)
            {
                IdentifiedEntityDispositionInformations type = new IdentifiedEntityDispositionInformations();
                type.Deserialize(reader);
                Dispositions.Add(type);
            }
        }
    }
}