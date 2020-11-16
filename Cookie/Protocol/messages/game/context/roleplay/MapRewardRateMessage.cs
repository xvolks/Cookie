using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRewardRateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6827;
        public override uint MessageID { get { return ProtocolId; } }

        public short MapRate = 0;
        public short SubAreaRate = 0;
        public short TotalRate = 0;

        public MapRewardRateMessage()
        {
        }

        public MapRewardRateMessage(
            short mapRate,
            short subAreaRate,
            short totalRate
        )
        {
            MapRate = mapRate;
            SubAreaRate = subAreaRate;
            TotalRate = totalRate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(MapRate);
            writer.WriteVarShort(SubAreaRate);
            writer.WriteVarShort(TotalRate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapRate = reader.ReadVarShort();
            SubAreaRate = reader.ReadVarShort();
            TotalRate = reader.ReadVarShort();
        }
    }
}