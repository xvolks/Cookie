using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    public class TeleportDestinationsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5960;

        public TeleportDestinationsListMessage(byte teleporterType, List<int> mapIds, List<ushort> subAreaIds,
            List<ushort> costs, List<byte> destTeleporterType)
        {
            TeleporterType = teleporterType;
            MapIds = mapIds;
            SubAreaIds = subAreaIds;
            Costs = costs;
            DestTeleporterType = destTeleporterType;
        }

        public TeleportDestinationsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte TeleporterType { get; set; }
        public List<int> MapIds { get; set; }
        public List<ushort> SubAreaIds { get; set; }
        public List<ushort> Costs { get; set; }
        public List<byte> DestTeleporterType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TeleporterType);
            writer.WriteShort((short) MapIds.Count);
            for (var mapIdsIndex = 0; mapIdsIndex < MapIds.Count; mapIdsIndex++)
                writer.WriteInt(MapIds[mapIdsIndex]);
            writer.WriteShort((short) SubAreaIds.Count);
            for (var subAreaIdsIndex = 0; subAreaIdsIndex < SubAreaIds.Count; subAreaIdsIndex++)
                writer.WriteVarUhShort(SubAreaIds[subAreaIdsIndex]);
            writer.WriteShort((short) Costs.Count);
            for (var costsIndex = 0; costsIndex < Costs.Count; costsIndex++)
                writer.WriteVarUhShort(Costs[costsIndex]);
            writer.WriteShort((short) DestTeleporterType.Count);
            for (var destTeleporterTypeIndex = 0;
                destTeleporterTypeIndex < DestTeleporterType.Count;
                destTeleporterTypeIndex++)
                writer.WriteByte(DestTeleporterType[destTeleporterTypeIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeleporterType = reader.ReadByte();
            var mapIdsCount = reader.ReadUShort();
            MapIds = new List<int>();
            for (var mapIdsIndex = 0; mapIdsIndex < mapIdsCount; mapIdsIndex++)
                MapIds.Add(reader.ReadInt());
            var subAreaIdsCount = reader.ReadUShort();
            SubAreaIds = new List<ushort>();
            for (var subAreaIdsIndex = 0; subAreaIdsIndex < subAreaIdsCount; subAreaIdsIndex++)
                SubAreaIds.Add(reader.ReadVarUhShort());
            var costsCount = reader.ReadUShort();
            Costs = new List<ushort>();
            for (var costsIndex = 0; costsIndex < costsCount; costsIndex++)
                Costs.Add(reader.ReadVarUhShort());
            var destTeleporterTypeCount = reader.ReadUShort();
            DestTeleporterType = new List<byte>();
            for (var destTeleporterTypeIndex = 0;
                destTeleporterTypeIndex < destTeleporterTypeCount;
                destTeleporterTypeIndex++)
                DestTeleporterType.Add(reader.ReadByte());
        }
    }
}