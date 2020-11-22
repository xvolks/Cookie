using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorAttackedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5918;

        public override ushort MessageID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public BasicGuildInformations Guild { get; set; }
        public TaxCollectorAttackedMessage() { }

        public TaxCollectorAttackedMessage( ushort FirstNameId, ushort LastNameId, short WorldX, short WorldY, double MapId, ushort SubAreaId, BasicGuildInformations Guild ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Guild = Guild;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}
