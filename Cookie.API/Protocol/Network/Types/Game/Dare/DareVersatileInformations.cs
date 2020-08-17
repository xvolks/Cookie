using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Dare
{
    public class DareVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 504;

        public DareVersatileInformations(double dareId, int countEntrants, int countWinners)
        {
            DareId = dareId;
            CountEntrants = countEntrants;
            CountWinners = countWinners;
        }

        public DareVersatileInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double DareId { get; set; }
        public int CountEntrants { get; set; }
        public int CountWinners { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteInt(CountEntrants);
            writer.WriteInt(CountWinners);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            CountEntrants = reader.ReadInt();
            CountWinners = reader.ReadInt();
        }
    }
}