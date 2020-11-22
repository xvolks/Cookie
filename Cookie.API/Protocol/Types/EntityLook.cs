using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class EntityLook : NetworkType
    {
        public const ushort ProtocolId = 55;

        public override ushort TypeID => ProtocolId;

        public ushort BonesId { get; set; }
        public List<short> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }
        public List<SubEntity> Subentities { get; set; }
        public EntityLook() { }

        public EntityLook( ushort BonesId, List<short> Skins, List<int> IndexedColors, List<short> Scales, List<SubEntity> Subentities ){
            this.BonesId = BonesId;
            this.Skins = Skins;
            this.IndexedColors = IndexedColors;
            this.Scales = Scales;
            this.Subentities = Subentities;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(BonesId);
			writer.WriteShort((short)Skins.Count);
			foreach (var x in Skins)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)IndexedColors.Count);
			foreach (var x in IndexedColors)
			{
				writer.WriteInt(x);
			}
			writer.WriteShort((short)Scales.Count);
			foreach (var x in Scales)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)Subentities.Count);
			foreach (var x in Subentities)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            BonesId = reader.ReadVarUhShort();
            var SkinsCount = reader.ReadShort();
            Skins = new List<short>();
            for (var i = 0; i < SkinsCount; i++)
            {
                Skins.Add(reader.ReadVarShort());
            }
            var IndexedColorsCount = reader.ReadShort();
            IndexedColors = new List<int>();
            for (var i = 0; i < IndexedColorsCount; i++)
            {
                IndexedColors.Add(reader.ReadInt());
            }
            var ScalesCount = reader.ReadShort();
            Scales = new List<short>();
            for (var i = 0; i < ScalesCount; i++)
            {
                Scales.Add(reader.ReadVarShort());
            }
            var SubentitiesCount = reader.ReadShort();
            Subentities = new List<SubEntity>();
            for (var i = 0; i < SubentitiesCount; i++)
            {
                var objectToAdd = new SubEntity();
                objectToAdd.Deserialize(reader);
                Subentities.Add(objectToAdd);
            }
        }
    }
}
