using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorInformations : NetworkType
    {
        public const short ProtocolId = 167;
        public override short TypeId { get { return ProtocolId; } }

        public double UniqueId = 0;
        public short FirtNameId = 0;
        public short LastNameId = 0;
        public AdditionalTaxCollectorInformations AdditionalInfos;
        public short WorldX = 0;
        public short WorldY = 0;
        public short SubAreaId = 0;
        public byte State = 0;
        public EntityLook Look;
        public List<TaxCollectorComplementaryInformations> Complements;

        public TaxCollectorInformations()
        {
        }

        public TaxCollectorInformations(
            double uniqueId,
            short firtNameId,
            short lastNameId,
            AdditionalTaxCollectorInformations additionalInfos,
            short worldX,
            short worldY,
            short subAreaId,
            byte state,
            EntityLook look,
            List<TaxCollectorComplementaryInformations> complements
        )
        {
            UniqueId = uniqueId;
            FirtNameId = firtNameId;
            LastNameId = lastNameId;
            AdditionalInfos = additionalInfos;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            State = state;
            Look = look;
            Complements = complements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteVarShort(FirtNameId);
            writer.WriteVarShort(LastNameId);
            AdditionalInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarShort(SubAreaId);
            writer.WriteByte(State);
            Look.Serialize(writer);
            writer.WriteShort((short)Complements.Count());
            foreach (var current in Complements)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            UniqueId = reader.ReadDouble();
            FirtNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            AdditionalInfos = new AdditionalTaxCollectorInformations();
            AdditionalInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarShort();
            State = reader.ReadByte();
            Look = new EntityLook();
            Look.Deserialize(reader);
            var countComplements = reader.ReadShort();
            Complements = new List<TaxCollectorComplementaryInformations>();
            for (short i = 0; i < countComplements; i++)
            {
                var complementstypeId = reader.ReadShort();
                TaxCollectorComplementaryInformations type = new TaxCollectorComplementaryInformations();
                type.Deserialize(reader);
                Complements.Add(type);
            }
        }
    }
}