using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public new const ushort ProtocolId = 46;

        public override ushort TypeID => ProtocolId;

        public ushort Level { get; set; }
        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public GameFightCharacterInformations() { }

        public GameFightCharacterInformations( ushort Level, ActorAlignmentInformations AlignmentInfos, sbyte Breed, bool Sex ){
            this.Level = Level;
            this.AlignmentInfos = AlignmentInfos;
            this.Breed = Breed;
            this.Sex = Sex;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Level);
            AlignmentInfos.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUhShort();
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}
