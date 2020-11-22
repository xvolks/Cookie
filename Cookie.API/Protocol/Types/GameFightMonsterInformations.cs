using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public new const ushort ProtocolId = 29;

        public override ushort TypeID => ProtocolId;

        public ushort CreatureGenericId { get; set; }
        public sbyte CreatureGrade { get; set; }
        public short CreatureLevel { get; set; }
        public GameFightMonsterInformations() { }

        public GameFightMonsterInformations( ushort CreatureGenericId, sbyte CreatureGrade, short CreatureLevel ){
            this.CreatureGenericId = CreatureGenericId;
            this.CreatureGrade = CreatureGrade;
            this.CreatureLevel = CreatureLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CreatureGenericId);
            writer.WriteSByte(CreatureGrade);
            writer.WriteShort(CreatureLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarUhShort();
            CreatureGrade = reader.ReadSByte();
            CreatureLevel = reader.ReadShort();
        }
    }
}
