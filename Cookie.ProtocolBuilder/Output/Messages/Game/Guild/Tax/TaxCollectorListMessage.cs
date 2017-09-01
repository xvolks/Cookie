namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Guild.Tax;
    using Types.Game.Guild.Tax;
    using System.Collections.Generic;
    using Utils.IO;

    public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const ushort ProtocolId = 5930;
        public override ushort MessageID => ProtocolId;
        public byte NbcollectorMax { get; set; }
        public List<TaxCollectorFightersInformation> FightersInformations { get; set; }

        public TaxCollectorListMessage(byte nbcollectorMax, List<TaxCollectorFightersInformation> fightersInformations)
        {
            NbcollectorMax = nbcollectorMax;
            FightersInformations = fightersInformations;
        }

        public TaxCollectorListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbcollectorMax);
            writer.WriteShort((short)FightersInformations.Count);
            for (var fightersInformationsIndex = 0; fightersInformationsIndex < FightersInformations.Count; fightersInformationsIndex++)
            {
                var objectToSend = FightersInformations[fightersInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbcollectorMax = reader.ReadByte();
            var fightersInformationsCount = reader.ReadUShort();
            FightersInformations = new List<TaxCollectorFightersInformation>();
            for (var fightersInformationsIndex = 0; fightersInformationsIndex < fightersInformationsCount; fightersInformationsIndex++)
            {
                var objectToAdd = new TaxCollectorFightersInformation();
                objectToAdd.Deserialize(reader);
                FightersInformations.Add(objectToAdd);
            }
        }

    }
}
