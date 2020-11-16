using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachBonusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6800;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectEffectInteger Bonus;

        public BreachBonusMessage()
        {
        }

        public BreachBonusMessage(
            ObjectEffectInteger bonus
        )
        {
            Bonus = bonus;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Bonus.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Bonus = new ObjectEffectInteger();
            Bonus.Deserialize(reader);
        }
    }
}