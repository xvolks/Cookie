using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeWeightMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5793;

        public override ushort MessageID => ProtocolId;

        public uint CurrentWeight { get; set; }
        public uint MaxWeight { get; set; }
        public ExchangeWeightMessage() { }

        public ExchangeWeightMessage( uint CurrentWeight, uint MaxWeight ){
            this.CurrentWeight = CurrentWeight;
            this.MaxWeight = MaxWeight;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(CurrentWeight);
            writer.WriteVarUhInt(MaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            CurrentWeight = reader.ReadVarUhInt();
            MaxWeight = reader.ReadVarUhInt();
        }
    }
}
