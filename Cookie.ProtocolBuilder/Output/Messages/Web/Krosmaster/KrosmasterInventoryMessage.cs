namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    using Types.Web.Krosmaster;
    using System.Collections.Generic;
    using Utils.IO;

    public class KrosmasterInventoryMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6350;
        public override ushort MessageID => ProtocolId;
        public List<KrosmasterFigure> Figures { get; set; }

        public KrosmasterInventoryMessage(List<KrosmasterFigure> figures)
        {
            Figures = figures;
        }

        public KrosmasterInventoryMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Figures.Count);
            for (var figuresIndex = 0; figuresIndex < Figures.Count; figuresIndex++)
            {
                var objectToSend = Figures[figuresIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var figuresCount = reader.ReadUShort();
            Figures = new List<KrosmasterFigure>();
            for (var figuresIndex = 0; figuresIndex < figuresCount; figuresIndex++)
            {
                var objectToAdd = new KrosmasterFigure();
                objectToAdd.Deserialize(reader);
                Figures.Add(objectToAdd);
            }
        }

    }
}
