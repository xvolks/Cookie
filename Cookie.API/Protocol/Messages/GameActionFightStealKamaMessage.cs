using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightStealKamaMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5535;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public ulong Amount { get; set; }
        public GameActionFightStealKamaMessage() { }

        public GameActionFightStealKamaMessage( double TargetId, ulong Amount ){
            this.TargetId = TargetId;
            this.Amount = Amount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhLong(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUhLong();
        }
    }
}
