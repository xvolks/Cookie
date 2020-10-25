using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterLightInformations : NetworkType
    {
        public const short ProtocolId = 413;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;
        public bool Alive = false;
        public double Id_ = 0;
        public byte Wave = 0;
        public short Level = 0;
        public byte Breed = 0;

        public GameFightFighterLightInformations()
        {
        }

        public GameFightFighterLightInformations(
            bool sex,
            bool alive,
            double id_,
            byte wave,
            short level,
            byte breed
        )
        {
            Sex = sex;
            Alive = alive;
            Id_ = id_;
            Wave = wave;
            Level = level;
            Breed = breed;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Sex);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Alive);
            writer.WriteByte(box0);
            writer.WriteDouble(Id_);
            writer.WriteByte(Wave);
            writer.WriteVarShort(Level);
            writer.WriteByte(Breed);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(box0, 1);
            Alive = BooleanByteWrapper.GetFlag(box0, 2);
            Id_ = reader.ReadDouble();
            Wave = reader.ReadByte();
            Level = reader.ReadVarShort();
            Breed = reader.ReadByte();
        }
    }
}