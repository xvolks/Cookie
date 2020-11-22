using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachBonusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6800;

        public override ushort MessageID => ProtocolId;

        public ObjectEffectInteger Bonus { get; set; }
        public BreachBonusMessage() { }

        public BreachBonusMessage( ObjectEffectInteger Bonus ){
            this.Bonus = Bonus;
        }

        public override void Serialize(IDataWriter writer)
        {
            Bonus.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bonus = new ObjectEffectInteger();
            Bonus.Deserialize(reader);
        }
    }
}
