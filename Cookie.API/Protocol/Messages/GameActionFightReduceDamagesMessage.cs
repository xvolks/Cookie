using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5526;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public uint Amount { get; set; }
        public GameActionFightReduceDamagesMessage() { }

        public GameActionFightReduceDamagesMessage( double TargetId, uint Amount ){
            this.TargetId = TargetId;
            this.Amount = Amount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Amount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarUhInt();
        }
    }
}
