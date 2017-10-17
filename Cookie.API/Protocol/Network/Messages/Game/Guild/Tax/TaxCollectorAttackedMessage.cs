using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorAttackedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5918;

        public TaxCollectorAttackedMessage(ushort firstNameId, ushort lastNameId, short worldX, short worldY,
            double mapId, ushort subAreaId, BasicGuildInformations guild)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Guild = guild;
        }

        public TaxCollectorAttackedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public BasicGuildInformations Guild { get; set; }

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