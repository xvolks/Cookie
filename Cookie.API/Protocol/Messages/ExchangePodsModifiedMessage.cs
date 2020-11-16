using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangePodsModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6670;

        public override ushort MessageID => ProtocolId;

        public uint CurrentWeight { get; set; }
        public uint MaxWeight { get; set; }
        public ExchangePodsModifiedMessage() { }

        public ExchangePodsModifiedMessage( uint CurrentWeight, uint MaxWeight ){
            this.CurrentWeight = CurrentWeight;
            this.MaxWeight = MaxWeight;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(CurrentWeight);
            writer.WriteVarUhInt(MaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CurrentWeight = reader.ReadVarUhInt();
            MaxWeight = reader.ReadVarUhInt();
        }
    }
}
