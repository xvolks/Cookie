using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MonsterBoosts : NetworkType
    {
        public const short ProtocolId = 497;
        public override short TypeId { get { return ProtocolId; } }

        public int Id_ = 0;
        public short XpBoost = 0;
        public short DropBoost = 0;

        public MonsterBoosts()
        {
        }

        public MonsterBoosts(
            int id_,
            short xpBoost,
            short dropBoost
        )
        {
            Id_ = id_;
            XpBoost = xpBoost;
            DropBoost = dropBoost;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Id_);
            writer.WriteVarShort(XpBoost);
            writer.WriteVarShort(DropBoost);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarInt();
            XpBoost = reader.ReadVarShort();
            DropBoost = reader.ReadVarShort();
        }
    }
}