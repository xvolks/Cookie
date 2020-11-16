using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MonsterBoosts : NetworkType
    {
        public const ushort ProtocolId = 497;

        public override ushort TypeID => ProtocolId;

        public uint Id { get; set; }
        public ushort XpBoost { get; set; }
        public ushort DropBoost { get; set; }
        public MonsterBoosts() { }

        public MonsterBoosts( uint Id, ushort XpBoost, ushort DropBoost ){
            this.Id = Id;
            this.XpBoost = XpBoost;
            this.DropBoost = DropBoost;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Id);
            writer.WriteVarUhShort(XpBoost);
            writer.WriteVarUhShort(DropBoost);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhInt();
            XpBoost = reader.ReadVarUhShort();
            DropBoost = reader.ReadVarUhShort();
        }
    }
}
