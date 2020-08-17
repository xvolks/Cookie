using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorInformations : NetworkType
    {
        public const ushort ProtocolId = 167;

        public TaxCollectorInformations(double uniqueId, ushort firtNameId, ushort lastNameId,
            AdditionalTaxCollectorInformations additionalInfos, short worldX, short worldY, ushort subAreaId,
            byte state, EntityLook look, List<TaxCollectorComplementaryInformations> complements)
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

        public TaxCollectorInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double UniqueId { get; set; }
        public ushort FirtNameId { get; set; }
        public ushort LastNameId { get; set; }
        public AdditionalTaxCollectorInformations AdditionalInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public ushort SubAreaId { get; set; }
        public byte State { get; set; }
        public EntityLook Look { get; set; }
        public List<TaxCollectorComplementaryInformations> Complements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteVarUhShort(FirtNameId);
            writer.WriteVarUhShort(LastNameId);
            AdditionalInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteByte(State);
            Look.Serialize(writer);
            writer.WriteShort((short) Complements.Count);
            for (var complementsIndex = 0; complementsIndex < Complements.Count; complementsIndex++)
            {
                var objectToSend = Complements[complementsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            UniqueId = reader.ReadDouble();
            FirtNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            AdditionalInfos = new AdditionalTaxCollectorInformations();
            AdditionalInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarUhShort();
            State = reader.ReadByte();
            Look = new EntityLook();
            Look.Deserialize(reader);
            var complementsCount = reader.ReadUShort();
            Complements = new List<TaxCollectorComplementaryInformations>();
            for (var complementsIndex = 0; complementsIndex < complementsCount; complementsIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<TaxCollectorComplementaryInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Complements.Add(objectToAdd);
            }
        }
    }
}