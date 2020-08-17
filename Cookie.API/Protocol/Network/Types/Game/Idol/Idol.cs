using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Idol
{
    public class Idol : NetworkType
    {
        public const ushort ProtocolId = 489;

        public Idol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent)
        {
            ObjectId = objectId;
            XpBonusPercent = xpBonusPercent;
            DropBonusPercent = dropBonusPercent;
        }

        public Idol()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }
        public ushort XpBonusPercent { get; set; }
        public ushort DropBonusPercent { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
            writer.WriteVarUhShort(XpBonusPercent);
            writer.WriteVarUhShort(DropBonusPercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
            XpBonusPercent = reader.ReadVarUhShort();
            DropBonusPercent = reader.ReadVarUhShort();
        }
    }
}