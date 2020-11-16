using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachRewardBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6803;

        public override ushort MessageID => ProtocolId;

        public uint Id { get; set; }
        public BreachRewardBuyMessage() { }

        public BreachRewardBuyMessage( uint Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhInt();
        }
    }
}
