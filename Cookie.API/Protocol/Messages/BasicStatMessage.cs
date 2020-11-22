using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicStatMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6530;

        public override ushort MessageID => ProtocolId;

        public double TimeSpent { get; set; }
        public ushort StatId { get; set; }
        public BasicStatMessage() { }

        public BasicStatMessage( double TimeSpent, ushort StatId ){
            this.TimeSpent = TimeSpent;
            this.StatId = StatId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TimeSpent);
            writer.WriteVarUhShort(StatId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TimeSpent = reader.ReadDouble();
            StatId = reader.ReadVarUhShort();
        }
    }
}
