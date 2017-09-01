using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class MonsterBoosts : NetworkType
    {
        public const ushort ProtocolId = 497;

        public MonsterBoosts(uint objectId, ushort xpBoost, ushort dropBoost)
        {
            ObjectId = objectId;
            XpBoost = xpBoost;
            DropBoost = dropBoost;
        }

        public MonsterBoosts()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint ObjectId { get; set; }
        public ushort XpBoost { get; set; }
        public ushort DropBoost { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectId);
            writer.WriteVarUhShort(XpBoost);
            writer.WriteVarUhShort(DropBoost);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhInt();
            XpBoost = reader.ReadVarUhShort();
            DropBoost = reader.ReadVarUhShort();
        }
    }
}