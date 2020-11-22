using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorAttackedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5918;
        public override uint MessageID { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public BasicGuildInformations Guild;

        public TaxCollectorAttackedMessage()
        {
        }

        public TaxCollectorAttackedMessage(
            short firstNameId,
            short lastNameId,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            BasicGuildInformations guild
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Guild = guild;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            Guild.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}