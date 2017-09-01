using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class PartyMemberInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 90;

        public PartyMemberInformations(uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate,
            ushort initiative, sbyte alignmentSide, short worldX, short worldY, int mapId, ushort subAreaId,
            PlayerStatus status, List<PartyCompanionMemberInformations> companions)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
            Initiative = initiative;
            AlignmentSide = alignmentSide;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Status = status;
            Companions = companions;
        }

        public PartyMemberInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }
        public ushort Initiative { get; set; }
        public sbyte AlignmentSide { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public PlayerStatus Status { get; set; }
        public List<PartyCompanionMemberInformations> Companions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteByte(RegenRate);
            writer.WriteVarUhShort(Initiative);
            writer.WriteSByte(AlignmentSide);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
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
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            Prospecting = reader.ReadVarUhShort();
            RegenRate = reader.ReadByte();
            Initiative = reader.ReadVarUhShort();
            AlignmentSide = reader.ReadSByte();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
            var companionsCount = reader.ReadUShort();
            Companions = new List<PartyCompanionMemberInformations>();
            for (var companionsIndex = 0; companionsIndex < companionsCount; companionsIndex++)
            {
                var objectToAdd = new PartyCompanionMemberInformations();
                objectToAdd.Deserialize(reader);
                Companions.Add(objectToAdd);
            }
        }
    }
}