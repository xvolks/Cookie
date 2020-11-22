using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TeleportDestination : NetworkType
    {
        public const short ProtocolId = 563;
        public override short TypeId { get { return ProtocolId; } }

        public byte Type = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public short Level = 0;
        public short Cost = 0;

        public TeleportDestination()
        {
        }

        public TeleportDestination(
            byte type,
            double mapId,
            short subAreaId,
            short level,
            short cost
        )
        {
            Type = type;
            MapId = mapId;
            SubAreaId = subAreaId;
            Level = level;
            Cost = cost;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarShort(Level);
            writer.WriteVarShort(Cost);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            Level = reader.ReadVarShort();
            Cost = reader.ReadVarShort();
        }
    }
}