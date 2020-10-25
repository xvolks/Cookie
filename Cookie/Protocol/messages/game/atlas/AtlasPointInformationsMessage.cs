using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AtlasPointInformationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5956;
        public override uint MessageID { get { return ProtocolId; } }

        public AtlasPointsInformations Type;

        public AtlasPointInformationsMessage()
        {
        }

        public AtlasPointInformationsMessage(
            AtlasPointsInformations type
        )
        {
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Type.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = new AtlasPointsInformations();
            Type.Deserialize(reader);
        }
    }
}