using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 376;

        public PartyInvitationMemberInformations(short worldX, short worldY, int mapId, ushort subAreaId,
            List<PartyCompanionBaseInformations> companions)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Companions = companions;
        }

        public PartyInvitationMemberInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public List<PartyCompanionBaseInformations> Companions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteShort((short) Companions.Count);
            for (var companionsIndex = 0; companionsIndex < Companions.Count; companionsIndex++)
            {
                var objectToSend = Companions[companionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
            var companionsCount = reader.ReadUShort();
            Companions = new List<PartyCompanionBaseInformations>();
            for (var companionsIndex = 0; companionsIndex < companionsCount; companionsIndex++)
            {
                var objectToAdd = new PartyCompanionBaseInformations();
                objectToAdd.Deserialize(reader);
                Companions.Add(objectToAdd);
            }
        }
    }
}