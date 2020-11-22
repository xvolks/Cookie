using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachGameFightEndMessage : GameFightEndMessage
    {
        public new const ushort ProtocolId = 6809;

        public override ushort MessageID => ProtocolId;

        public int Budget { get; set; }
        public BreachGameFightEndMessage() { }

        public BreachGameFightEndMessage( int Budget ){
            this.Budget = Budget;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Budget);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Budget = reader.ReadInt();
        }
    }
}
