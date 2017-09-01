using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Look
{
    public class EntityLook : NetworkType
    {
        public const ushort ProtocolId = 55;

        public EntityLook(ushort bonesId, List<ushort> skins, List<int> indexedColors, List<short> scales,
            List<SubEntity> subentities)
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            Subentities = subentities;
        }

        public EntityLook()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort BonesId { get; set; }
        public List<ushort> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }
        public List<SubEntity> Subentities { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(BonesId);
            writer.WriteShort((short) Skins.Count);
            for (var skinsIndex = 0; skinsIndex < Skins.Count; skinsIndex++)
                writer.WriteVarUhShort(Skins[skinsIndex]);
            writer.WriteShort((short) IndexedColors.Count);
            for (var indexedColorsIndex = 0; indexedColorsIndex < IndexedColors.Count; indexedColorsIndex++)
                writer.WriteInt(IndexedColors[indexedColorsIndex]);
            writer.WriteShort((short) Scales.Count);
            for (var scalesIndex = 0; scalesIndex < Scales.Count; scalesIndex++)
                writer.WriteVarShort(Scales[scalesIndex]);
            writer.WriteShort((short) Subentities.Count);
            for (var subentitiesIndex = 0; subentitiesIndex < Subentities.Count; subentitiesIndex++)
            {
                var objectToSend = Subentities[subentitiesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            BonesId = reader.ReadVarUhShort();
            var skinsCount = reader.ReadUShort();
            Skins = new List<ushort>();
            for (var skinsIndex = 0; skinsIndex < skinsCount; skinsIndex++)
                Skins.Add(reader.ReadVarUhShort());
            var indexedColorsCount = reader.ReadUShort();
            IndexedColors = new List<int>();
            for (var indexedColorsIndex = 0; indexedColorsIndex < indexedColorsCount; indexedColorsIndex++)
                IndexedColors.Add(reader.ReadInt());
            var scalesCount = reader.ReadUShort();
            Scales = new List<short>();
            for (var scalesIndex = 0; scalesIndex < scalesCount; scalesIndex++)
                Scales.Add(reader.ReadVarShort());
            var subentitiesCount = reader.ReadUShort();
            Subentities = new List<SubEntity>();
            for (var subentitiesIndex = 0; subentitiesIndex < subentitiesCount; subentitiesIndex++)
            {
                var objectToAdd = new SubEntity();
                objectToAdd.Deserialize(reader);
                Subentities.Add(objectToAdd);
            }
        }
    }
}