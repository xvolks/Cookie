using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6311;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public uint Delta { get; set; }
        public GameActionFightLifePointsGainMessage() { }

        public GameActionFightLifePointsGainMessage( double TargetId, uint Delta ){
            this.TargetId = TargetId;
            this.Delta = Delta;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadVarUhInt();
        }
    }
}
