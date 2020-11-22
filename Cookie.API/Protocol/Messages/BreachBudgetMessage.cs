using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachBudgetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6786;

        public override ushort MessageID => ProtocolId;

        public uint Bugdet { get; set; }
        public BreachBudgetMessage() { }

        public BreachBudgetMessage( uint Bugdet ){
            this.Bugdet = Bugdet;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Bugdet);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bugdet = reader.ReadVarUhInt();
        }
    }
}
