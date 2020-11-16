using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MonsterInGroupLightInformations : NetworkType
    {
        public const ushort ProtocolId = 395;

        public override ushort TypeID => ProtocolId;

        public int GenericId { get; set; }
        public sbyte Grade { get; set; }
        public short Level { get; set; }
        public MonsterInGroupLightInformations() { }

        public MonsterInGroupLightInformations( int GenericId, sbyte Grade, short Level ){
            this.GenericId = GenericId;
            this.Grade = Grade;
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(GenericId);
            writer.WriteSByte(Grade);
            writer.WriteShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenericId = reader.ReadInt();
            Grade = reader.ReadSByte();
            Level = reader.ReadShort();
        }
    }
}
