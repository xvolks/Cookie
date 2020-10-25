using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MonsterInGroupLightInformations : NetworkType
    {
        public const short ProtocolId = 395;
        public override short TypeId { get { return ProtocolId; } }

        public int GenericId = 0;
        public byte Grade = 0;
        public short Level = 0;

        public MonsterInGroupLightInformations()
        {
        }

        public MonsterInGroupLightInformations(
            int genericId,
            byte grade,
            short level
        )
        {
            GenericId = genericId;
            Grade = grade;
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(GenericId);
            writer.WriteByte(Grade);
            writer.WriteShort(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GenericId = reader.ReadInt();
            Grade = reader.ReadByte();
            Level = reader.ReadShort();
        }
    }
}