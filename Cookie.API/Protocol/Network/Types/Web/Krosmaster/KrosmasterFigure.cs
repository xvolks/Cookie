using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Web.Krosmaster
{
    public class KrosmasterFigure : NetworkType
    {
        public const ushort ProtocolId = 397;

        public KrosmasterFigure(string uid, ushort figure, ushort pedestal, bool bound)
        {
            Uid = uid;
            Figure = figure;
            Pedestal = pedestal;
            Bound = bound;
        }

        public KrosmasterFigure()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Uid { get; set; }
        public ushort Figure { get; set; }
        public ushort Pedestal { get; set; }
        public bool Bound { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Uid);
            writer.WriteVarUhShort(Figure);
            writer.WriteVarUhShort(Pedestal);
            writer.WriteBoolean(Bound);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadUTF();
            Figure = reader.ReadVarUhShort();
            Pedestal = reader.ReadVarUhShort();
            Bound = reader.ReadBoolean();
        }
    }
}