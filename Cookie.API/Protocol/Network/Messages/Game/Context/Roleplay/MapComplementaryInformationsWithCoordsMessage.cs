using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6268;

        public MapComplementaryInformationsWithCoordsMessage(short worldX, short worldY)
        {
            WorldX = worldX;
            WorldY = worldY;
        }

        public MapComplementaryInformationsWithCoordsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short WorldX { get; set; }
        public short WorldY { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}