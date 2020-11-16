using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class Idol : NetworkType
    {
        public const ushort ProtocolId = 489;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public ushort XpBonusPercent { get; set; }
        public ushort DropBonusPercent { get; set; }
        public Idol() { }

        public Idol( ushort Id, ushort XpBonusPercent, ushort DropBonusPercent ){
            this.Id = Id;
            this.XpBonusPercent = XpBonusPercent;
            this.DropBonusPercent = DropBonusPercent;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
            writer.WriteVarUhShort(XpBonusPercent);
            writer.WriteVarUhShort(DropBonusPercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            XpBonusPercent = reader.ReadVarUhShort();
            DropBonusPercent = reader.ReadVarUhShort();
        }
    }
}
