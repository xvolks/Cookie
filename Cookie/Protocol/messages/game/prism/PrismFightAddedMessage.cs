using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6452;
        public override uint MessageID { get { return ProtocolId; } }

        public PrismFightersInformation Fight;

        public PrismFightAddedMessage()
        {
        }

        public PrismFightAddedMessage(
            PrismFightersInformation fight
        )
        {
            Fight = fight;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Fight.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Fight = new PrismFightersInformation();
            Fight.Deserialize(reader);
        }
    }
}