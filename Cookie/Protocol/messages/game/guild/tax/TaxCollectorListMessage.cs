using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const uint ProtocolId = 5930;
        public override uint MessageID { get { return ProtocolId; } }

        public byte NbcollectorMax = 0;
        public List<TaxCollectorFightersInformation> FightersInformations;
        public byte InfoType = 0;

        public TaxCollectorListMessage(): base()
        {
        }

        public TaxCollectorListMessage(
            List<TaxCollectorInformations> informations,
            byte nbcollectorMax,
            List<TaxCollectorFightersInformation> fightersInformations,
            byte infoType
        ): base(
            informations
        )
        {
            NbcollectorMax = nbcollectorMax;
            FightersInformations = fightersInformations;
            InfoType = infoType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbcollectorMax);
            writer.WriteShort((short)FightersInformations.Count());
            foreach (var current in FightersInformations)
            {
                current.Serialize(writer);
            }
            writer.WriteByte(InfoType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NbcollectorMax = reader.ReadByte();
            var countFightersInformations = reader.ReadShort();
            FightersInformations = new List<TaxCollectorFightersInformation>();
            for (short i = 0; i < countFightersInformations; i++)
            {
                TaxCollectorFightersInformation type = new TaxCollectorFightersInformation();
                type.Deserialize(reader);
                FightersInformations.Add(type);
            }
            InfoType = reader.ReadByte();
        }
    }
}