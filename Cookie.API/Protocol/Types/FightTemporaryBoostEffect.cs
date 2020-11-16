using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 209;

        public override ushort TypeID => ProtocolId;

        public short Delta { get; set; }
        public FightTemporaryBoostEffect() { }

        public FightTemporaryBoostEffect( short Delta ){
            this.Delta = Delta;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Delta = reader.ReadShort();
        }
    }
}
