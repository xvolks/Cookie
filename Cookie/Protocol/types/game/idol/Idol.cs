using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class Idol : NetworkType
    {
        public const short ProtocolId = 489;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;
        public short XpBonusPercent = 0;
        public short DropBonusPercent = 0;

        public Idol()
        {
        }

        public Idol(
            short id_,
            short xpBonusPercent,
            short dropBonusPercent
        )
        {
            Id_ = id_;
            XpBonusPercent = xpBonusPercent;
            DropBonusPercent = dropBonusPercent;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteVarShort(XpBonusPercent);
            writer.WriteVarShort(DropBonusPercent);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            XpBonusPercent = reader.ReadVarShort();
            DropBonusPercent = reader.ReadVarShort();
        }
    }
}