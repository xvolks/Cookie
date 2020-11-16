using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockContentInformations : PaddockInformations
    {
        public new const ushort ProtocolId = 183;

        public override ushort TypeID => ProtocolId;

        public double PaddockId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public bool Abandonned { get; set; }
        public List<MountInformationsForPaddock> MountsInformations { get; set; }
        public PaddockContentInformations() { }

        public PaddockContentInformations( double PaddockId, short WorldX, short WorldY, double MapId, ushort SubAreaId, bool Abandonned, List<MountInformationsForPaddock> MountsInformations ){
            this.PaddockId = PaddockId;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Abandonned = Abandonned;
            this.MountsInformations = MountsInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(PaddockId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteBoolean(Abandonned);
			writer.WriteShort((short)MountsInformations.Count);
			foreach (var x in MountsInformations)
			{
				x.Serialize(writer);
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
            var MountsInformationsCount = reader.ReadShort();
            MountsInformations = new List<MountInformationsForPaddock>();
            for (var i = 0; i < MountsInformationsCount; i++)
            {
                var objectToAdd = new MountInformationsForPaddock();
                objectToAdd.Deserialize(reader);
                MountsInformations.Add(objectToAdd);
            }
        }
    }
}
