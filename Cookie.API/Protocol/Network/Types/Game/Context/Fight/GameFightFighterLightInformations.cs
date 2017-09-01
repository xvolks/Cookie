using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightFighterLightInformations : NetworkType
    {
        public const ushort ProtocolId = 413;

        public GameFightFighterLightInformations(bool sex, bool alive, double objectId, byte wave, ushort level,
            sbyte breed)
        {
            Sex = sex;
            Alive = alive;
            ObjectId = objectId;
            Wave = wave;
            Level = level;
            Breed = breed;
        }

        public GameFightFighterLightInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool Sex { get; set; }
        public bool Alive { get; set; }
        public double ObjectId { get; set; }
        public byte Wave { get; set; }
        public ushort Level { get; set; }
        public sbyte Breed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
            flag = BooleanByteWrapper.SetFlag(1, flag, Alive);
            writer.WriteByte(flag);
            writer.WriteDouble(ObjectId);
            writer.WriteByte(Wave);
            writer.WriteVarUhShort(Level);
            writer.WriteSByte(Breed);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(flag, 0);
            Alive = BooleanByteWrapper.GetFlag(flag, 1);
            ObjectId = reader.ReadDouble();
            Wave = reader.ReadByte();
            Level = reader.ReadVarUhShort();
            Breed = reader.ReadSByte();
        }
    }
}