using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockBuyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6516;

        public override ushort MessageID => ProtocolId;

        public double PaddockId { get; set; }
        public bool Bought { get; set; }
        public ulong RealPrice { get; set; }
        public PaddockBuyResultMessage() { }

        public PaddockBuyResultMessage( double PaddockId, bool Bought, ulong RealPrice ){
            this.PaddockId = PaddockId;
            this.Bought = Bought;
            this.RealPrice = RealPrice;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
            writer.WriteBoolean(Bought);
            writer.WriteVarUhLong(RealPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
            Bought = reader.ReadBoolean();
            RealPrice = reader.ReadVarUhLong();
        }
    }
}
