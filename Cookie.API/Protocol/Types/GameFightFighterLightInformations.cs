using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterLightInformations : NetworkType
    {
        public const ushort ProtocolId = 413;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public bool Alive { get; set; }
        public double Id { get; set; }
        public sbyte Wave { get; set; }
        public ushort Level { get; set; }
        public sbyte Breed { get; set; }
        public GameFightFighterLightInformations() { }

        public GameFightFighterLightInformations( bool Sex, bool Alive, double Id, sbyte Wave, ushort Level, sbyte Breed ){
            this.Sex = Sex;
            this.Alive = Alive;
            this.Id = Id;
            this.Wave = Wave;
            this.Level = Level;
            this.Breed = Breed;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
			flag = BooleanByteWrapper.SetFlag(1, flag, Alive);
			writer.WriteByte(flag);
            writer.WriteDouble(Id);
            writer.WriteSByte(Wave);
            writer.WriteVarUhShort(Level);
            writer.WriteSByte(Breed);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Sex = BooleanByteWrapper.GetFlag(flag, 0);
			Alive = BooleanByteWrapper.GetFlag(flag, 1);
            Id = reader.ReadDouble();
            Wave = reader.ReadSByte();
            Level = reader.ReadVarUhShort();
            Breed = reader.ReadSByte();
        }
    }
}
