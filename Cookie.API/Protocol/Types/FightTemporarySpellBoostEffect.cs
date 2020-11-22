using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 207;

        public override ushort TypeID => ProtocolId;

        public ushort BoostedSpellId { get; set; }
        public FightTemporarySpellBoostEffect() { }

        public FightTemporarySpellBoostEffect( ushort BoostedSpellId ){
            this.BoostedSpellId = BoostedSpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(BoostedSpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BoostedSpellId = reader.ReadVarUhShort();
        }
    }
}
