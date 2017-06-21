using System.Collections.Generic;
using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.Look
{
    public class EntityLook : NetworkType
    {
        public const short ProtocolId = 55;

        public EntityLook()
        {
        }

        public EntityLook(ushort bonesId, List<ushort> skins, List<int> indexedColors, List<short> scales,
            List<SubEntity> subEntities)
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            SubEntities = subEntities;
        }

        public override short TypeID => ProtocolId;

        public ushort BonesId { get; set; }
        public List<ushort> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }
        public List<SubEntity> SubEntities { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(BonesId);
            writer.WriteShort((short) Skins.Count);
            for (var i = 0; i < Skins.Count; i++)
                writer.WriteVarUhShort(Skins[i]);
            writer.WriteShort((short) IndexedColors.Count);
            for (var i = 0; i < IndexedColors.Count; i++)
                writer.WriteInt(IndexedColors[i]);
            writer.WriteShort((short) Scales.Count);
            for (var i = 0; i < Scales.Count; i++)
                writer.WriteVarShort(Scales[i]);
            writer.WriteShort((short) SubEntities.Count);
            for (var i = 0; i < SubEntities.Count; i++)
            {
                var objectToSend = SubEntities[i];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BonesId = reader.ReadVarUhShort();
            var skinsLength = reader.ReadUShort();
            Skins = new List<ushort>();
            for (var i = 0; i < skinsLength; i++)
                Skins.Add(reader.ReadVarUhShort());
            var indexLength = reader.ReadUShort();
            IndexedColors = new List<int>();
            for (var i = 0; i < indexLength; i++)
                IndexedColors.Add(reader.ReadInt());
            var scalesLength = reader.ReadUShort();
            Scales = new List<short>();
            for (var i = 0; i < scalesLength; i++)
                Scales.Add(reader.ReadVarShort());
            var entitiesLength = reader.ReadUShort();
            SubEntities = new List<SubEntity>();
            for (var i = 0; i < entitiesLength; i++)
            {
                var objectToAdd = new SubEntity();
                objectToAdd.Deserialize(reader);
                SubEntities.Add(objectToAdd);
            }
        }
    }
}