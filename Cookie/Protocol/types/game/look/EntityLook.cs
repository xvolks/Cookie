using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class EntityLook : NetworkType
    {
        public const short ProtocolId = 55;
        public override short TypeId { get { return ProtocolId; } }

        public short BonesId = 0;
        public List<short> Skins;
        public List<int> IndexedColors;
        public List<short> Scales;
        public List<SubEntity> Subentities;

        public EntityLook()
        {
        }

        public EntityLook(
            short bonesId,
            List<short> skins,
            List<int> indexedColors,
            List<short> scales,
            List<SubEntity> subentities
        )
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            Subentities = subentities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(BonesId);
            writer.WriteShort((short)Skins.Count());
            foreach (var current in Skins)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)IndexedColors.Count());
            foreach (var current in IndexedColors)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort((short)Scales.Count());
            foreach (var current in Scales)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)Subentities.Count());
            foreach (var current in Subentities)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BonesId = reader.ReadVarShort();
            var countSkins = reader.ReadShort();
            Skins = new List<short>();
            for (short i = 0; i < countSkins; i++)
            {
                Skins.Add(reader.ReadVarShort());
            }
            var countIndexedColors = reader.ReadShort();
            IndexedColors = new List<int>();
            for (short i = 0; i < countIndexedColors; i++)
            {
                IndexedColors.Add(reader.ReadInt());
            }
            var countScales = reader.ReadShort();
            Scales = new List<short>();
            for (short i = 0; i < countScales; i++)
            {
                Scales.Add(reader.ReadVarShort());
            }
            var countSubentities = reader.ReadShort();
            Subentities = new List<SubEntity>();
            for (short i = 0; i < countSubentities; i++)
            {
                SubEntity type = new SubEntity();
                type.Deserialize(reader);
                Subentities.Add(type);
            }
        }
    }
}