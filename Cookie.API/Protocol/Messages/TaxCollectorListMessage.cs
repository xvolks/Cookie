using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const ushort ProtocolId = 5930;

        public override ushort MessageID => ProtocolId;

        public sbyte NbcollectorMax { get; set; }
        public List<TaxCollectorFightersInformation> FightersInformations { get; set; }
        public sbyte InfoType { get; set; }
        public TaxCollectorListMessage() { }

        public TaxCollectorListMessage( sbyte NbcollectorMax, List<TaxCollectorFightersInformation> FightersInformations, sbyte InfoType ){
            this.NbcollectorMax = NbcollectorMax;
            this.FightersInformations = FightersInformations;
            this.InfoType = InfoType;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(NbcollectorMax);
			writer.WriteShort((short)FightersInformations.Count);
			foreach (var x in FightersInformations)
			{
				x.Serialize(writer);
			}
            writer.WriteSByte(InfoType);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbcollectorMax = reader.ReadSByte();
            var FightersInformationsCount = reader.ReadShort();
            FightersInformations = new List<TaxCollectorFightersInformation>();
            for (var i = 0; i < FightersInformationsCount; i++)
            {
                var objectToAdd = new TaxCollectorFightersInformation();
                objectToAdd.Deserialize(reader);
                FightersInformations.Add(objectToAdd);
            }
            InfoType = reader.ReadSByte();
        }
    }
}
