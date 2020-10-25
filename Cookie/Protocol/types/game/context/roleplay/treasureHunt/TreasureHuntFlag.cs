using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntFlag : NetworkType
    {
        public const short ProtocolId = 473;
        public override short TypeId { get { return ProtocolId; } }

        public double MapId = 0;
        public byte State = 0;

        public TreasureHuntFlag()
        {
        }

        public TreasureHuntFlag(
            double mapId,
            byte state
        )
        {
            MapId = mapId;
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteByte(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            State = reader.ReadByte();
        }
    }
}