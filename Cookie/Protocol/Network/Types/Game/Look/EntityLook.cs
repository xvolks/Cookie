using Cookie.IO;
using System;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Types.Game.Look
{
    public class EntityLook : NetworkType
    {
        public const short ProtocolId = 55;
        public override short TypeID { get { return ProtocolId; } }

        public ushort BonesId { get; set; }
        public List<ushort> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }
        public List<SubEntity> SubEntities { get; set; }

        public EntityLook() { }

        public EntityLook(ushort bonesId, List<ushort> skins, List<int> indexedColors, List<short> scales, List<SubEntity> subEntities)
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            SubEntities = subEntities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(BonesId);
            writer.WriteShort(((short)(Skins.Count)));
            for (int i = 0; (i < Skins.Count); i++)
            {
                writer.WriteVarUhShort(Skins[i]);
            }
            writer.WriteShort(((short)(IndexedColors.Count)));
            for (int i = 0; (i < IndexedColors.Count); i++)
            {
                writer.WriteInt(IndexedColors[i]);
            }
            writer.WriteShort(((short)(Scales.Count)));
            for (int i = 0; (i < Scales.Count); i++)
            {
                writer.WriteVarShort(Scales[i]);
            }
            writer.WriteShort(((short)(SubEntities.Count)));
            for (int i = 0; (i < SubEntities.Count); i++)
            {
                SubEntity objectToSend = SubEntities[i];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BonesId = reader.ReadVarUhShort();
            ushort skinsLength = reader.ReadUShort();
            Skins = new List<ushort>();
            for (int i = 0; (i < skinsLength); i++)
            {
                Skins.Add(reader.ReadVarUhShort());
            }
            ushort indexLength = reader.ReadUShort();
            IndexedColors = new List<int>();
            for (int i = 0; (i < indexLength); i++)
            {
                IndexedColors.Add(reader.ReadInt());
            }
            ushort scalesLength = reader.ReadUShort();
            Scales = new List<short>();
            for (int i = 0; (i < scalesLength); i++)
            {
                Scales.Add(reader.ReadVarShort());
            }
            ushort entitiesLength = reader.ReadUShort();
            SubEntities = new List<SubEntity>();
            for (int i = 0; (i < entitiesLength); i++)
            {
                SubEntity objectToAdd = new SubEntity();
                objectToAdd.Deserialize(reader);
                SubEntities.Add(objectToAdd);
            }
        }
    }
}
