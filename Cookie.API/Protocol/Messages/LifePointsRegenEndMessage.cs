using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LifePointsRegenEndMessage : UpdateLifePointsMessage
    {
        public new const ushort ProtocolId = 5686;

        public override ushort MessageID => ProtocolId;

        public uint LifePointsGained { get; set; }
        public LifePointsRegenEndMessage() { }

        public LifePointsRegenEndMessage( uint LifePointsGained ){
            this.LifePointsGained = LifePointsGained;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(LifePointsGained);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LifePointsGained = reader.ReadVarUhInt();
        }
    }
}
