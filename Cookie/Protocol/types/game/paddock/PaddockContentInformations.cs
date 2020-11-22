using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockContentInformations : PaddockInformations
    {
        public new const short ProtocolId = 183;
        public override short TypeId { get { return ProtocolId; } }

        public double PaddockId = 0;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public bool Abandonned = false;
        public List<MountInformationsForPaddock> MountsInformations;

        public PaddockContentInformations(): base()
        {
        }

        public PaddockContentInformations(
            short maxOutdoorMount,
            short maxItems,
            double paddockId,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            bool abandonned,
            List<MountInformationsForPaddock> mountsInformations
        ): base(
            maxOutdoorMount,
            maxItems
        )
        {
            PaddockId = paddockId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Abandonned = abandonned;
            MountsInformations = mountsInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(PaddockId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteBoolean(Abandonned);
            writer.WriteShort((short)MountsInformations.Count());
            foreach (var current in MountsInformations)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PaddockId = reader.ReadDouble();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            Abandonned = reader.ReadBoolean();
            var countMountsInformations = reader.ReadShort();
            MountsInformations = new List<MountInformationsForPaddock>();
            for (short i = 0; i < countMountsInformations; i++)
            {
                MountInformationsForPaddock type = new MountInformationsForPaddock();
                type.Deserialize(reader);
                MountsInformations.Add(type);
            }
        }
    }
}