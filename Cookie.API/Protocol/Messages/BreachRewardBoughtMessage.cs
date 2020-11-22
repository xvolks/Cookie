using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachRewardBoughtMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6797;

        public override ushort MessageID => ProtocolId;

        public uint Id { get; set; }
        public bool Bought { get; set; }
        public BreachRewardBoughtMessage() { }

        public BreachRewardBoughtMessage( uint Id, bool Bought ){
            this.Id = Id;
            this.Bought = Bought;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Id);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhInt();
            Bought = reader.ReadBoolean();
        }
    }
}
