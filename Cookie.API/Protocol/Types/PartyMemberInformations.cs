using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyMemberInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 90;

        public override ushort TypeID => ProtocolId;

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }
        public ushort Initiative { get; set; }
        public sbyte AlignmentSide { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public PlayerStatus Status { get; set; }
        public List<PartyEntityBaseInformation> Entities { get; set; }
        public PartyMemberInformations() { }

        public PartyMemberInformations( uint LifePoints, uint MaxLifePoints, ushort Prospecting, byte RegenRate, ushort Initiative, sbyte AlignmentSide, short WorldX, short WorldY, double MapId, ushort SubAreaId, PlayerStatus Status, List<PartyEntityBaseInformation> Entities ){
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
            this.Prospecting = Prospecting;
            this.RegenRate = RegenRate;
            this.Initiative = Initiative;
            this.AlignmentSide = AlignmentSide;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Status = Status;
            this.Entities = Entities;
        }

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
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            Status.Serialize(writer);
			writer.WriteShort((short)Entities.Count);
			foreach (var x in Entities)
			{
				x.Serialize(writer);
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
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
            var EntitiesCount = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (var i = 0; i < EntitiesCount; i++)
            {
                PartyEntityBaseInformation objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Entities.Add(objectToAdd);
            }
        }
    }
}
