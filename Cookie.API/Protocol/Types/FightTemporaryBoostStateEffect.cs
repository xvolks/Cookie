using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 214;

        public override ushort TypeID => ProtocolId;

        public short StateId { get; set; }
        public FightTemporaryBoostStateEffect() { }

        public FightTemporaryBoostStateEffect( short StateId ){
            this.StateId = StateId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StateId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StateId = reader.ReadShort();
        }
    }
}
