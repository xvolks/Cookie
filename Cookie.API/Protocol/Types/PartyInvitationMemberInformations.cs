using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 376;

        public override ushort TypeID => ProtocolId;

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public List<PartyEntityBaseInformation> Entities { get; set; }
        public PartyInvitationMemberInformations() { }

        public PartyInvitationMemberInformations( short WorldX, short WorldY, double MapId, ushort SubAreaId, List<PartyEntityBaseInformation> Entities ){
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Entities = Entities;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
			writer.WriteShort((short)Entities.Count);
			foreach (var x in Entities)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            var EntitiesCount = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (var i = 0; i < EntitiesCount; i++)
            {
                var objectToAdd = new PartyEntityBaseInformation();
                objectToAdd.Deserialize(reader);
                Entities.Add(objectToAdd);
            }
        }
    }
}
