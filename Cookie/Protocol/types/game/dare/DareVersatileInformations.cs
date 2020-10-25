using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class DareVersatileInformations : NetworkType
    {
        public const short ProtocolId = 504;
        public override short TypeId { get { return ProtocolId; } }

        public double DareId = 0;
        public int CountEntrants = 0;
        public int CountWinners = 0;

        public DareVersatileInformations()
        {
        }

        public DareVersatileInformations(
            double dareId,
            int countEntrants,
            int countWinners
        )
        {
            DareId = dareId;
            CountEntrants = countEntrants;
            CountWinners = countWinners;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteInt(CountEntrants);
            writer.WriteInt(CountWinners);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareId = reader.ReadDouble();
            CountEntrants = reader.ReadInt();
            CountWinners = reader.ReadInt();
        }
    }
}