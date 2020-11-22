using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GoldAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6030;
        public override uint MessageID { get { return ProtocolId; } }

        public GoldItem Gold;

        public GoldAddedMessage()
        {
        }

        public GoldAddedMessage(
            GoldItem gold
        )
        {
            Gold = gold;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Gold.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Gold = new GoldItem();
            Gold.Deserialize(reader);
        }
    }
}