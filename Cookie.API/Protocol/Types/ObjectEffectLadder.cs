using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectLadder : ObjectEffectCreature
    {
        public new const ushort ProtocolId = 81;

        public override ushort TypeID => ProtocolId;

        public uint MonsterCount { get; set; }
        public ObjectEffectLadder() { }

        public ObjectEffectLadder( uint MonsterCount ){
            this.MonsterCount = MonsterCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(MonsterCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterCount = reader.ReadVarUhInt();
        }
    }
}
