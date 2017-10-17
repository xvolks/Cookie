using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    public class PaddockContentInformations : PaddockInformations
    {
        public new const ushort ProtocolId = 183;

        public PaddockContentInformations(double paddockId, short worldX, short worldY, double mapId, ushort subAreaId,
            bool abandonned, List<MountInformationsForPaddock> mountsInformations)
        {
            PaddockId = paddockId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Abandonned = abandonned;
            MountsInformations = mountsInformations;
        }

        public PaddockContentInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double PaddockId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public bool Abandonned { get; set; }
        public List<MountInformationsForPaddock> MountsInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(PaddockId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteBoolean(Abandonned);
            writer.WriteShort((short) MountsInformations.Count);
            for (var mountsInformationsIndex = 0;
                mountsInformationsIndex < MountsInformations.Count;
                mountsInformationsIndex++)
            {
                var objectToSend = MountsInformations[mountsInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PaddockId = reader.ReadDouble();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            Abandonned = reader.ReadBoolean();
            var mountsInformationsCount = reader.ReadUShort();
            MountsInformations = new List<MountInformationsForPaddock>();
            for (var mountsInformationsIndex = 0;
                mountsInformationsIndex < mountsInformationsCount;
                mountsInformationsIndex++)
            {
                var objectToAdd = new MountInformationsForPaddock();
                objectToAdd.Deserialize(reader);
                MountsInformations.Add(objectToAdd);
            }
        }
    }
}