using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorInformations : NetworkType
    {
        public const ushort ProtocolId = 167;

        public override ushort TypeID => ProtocolId;

        public double UniqueId { get; set; }
        public ushort FirtNameId { get; set; }
        public ushort LastNameId { get; set; }
        public AdditionalTaxCollectorInformations AdditionalInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public ushort SubAreaId { get; set; }
        public sbyte State { get; set; }
        public EntityLook Look { get; set; }
        public List<TaxCollectorComplementaryInformations> Complements { get; set; }
        public TaxCollectorInformations() { }

        public TaxCollectorInformations( double UniqueId, ushort FirtNameId, ushort LastNameId, AdditionalTaxCollectorInformations AdditionalInfos, short WorldX, short WorldY, ushort SubAreaId, sbyte State, EntityLook Look, List<TaxCollectorComplementaryInformations> Complements ){
            this.UniqueId = UniqueId;
            this.FirtNameId = FirtNameId;
            this.LastNameId = LastNameId;
            this.AdditionalInfos = AdditionalInfos;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.SubAreaId = SubAreaId;
            this.State = State;
            this.Look = Look;
            this.Complements = Complements;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteVarUhShort(FirtNameId);
            writer.WriteVarUhShort(LastNameId);
            AdditionalInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(State);
            Look.Serialize(writer);
			writer.WriteShort((short)Complements.Count);
			foreach (var x in Complements)
			{
				x.Serialize(writer);
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
            State = reader.ReadSByte();
            Look = new EntityLook();
            Look.Deserialize(reader);
            var ComplementsCount = reader.ReadShort();
            Complements = new List<TaxCollectorComplementaryInformations>();
            for (var i = 0; i < ComplementsCount; i++)
            {
                TaxCollectorComplementaryInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Complements.Add(objectToAdd);
            }
        }
    }
}
