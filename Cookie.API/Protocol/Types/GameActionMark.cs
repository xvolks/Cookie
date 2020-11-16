using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameActionMark : NetworkType
    {
        public const ushort ProtocolId = 351;

        public override ushort TypeID => ProtocolId;

        public double MarkAuthorId { get; set; }
        public sbyte MarkTeamId { get; set; }
        public int MarkSpellId { get; set; }
        public short MarkSpellLevel { get; set; }
        public short MarkId { get; set; }
        public sbyte MarkType { get; set; }
        public short MarkimpactCell { get; set; }
        public List<GameActionMarkedCell> Cells { get; set; }
        public bool Active { get; set; }
        public GameActionMark() { }

        public GameActionMark( double MarkAuthorId, sbyte MarkTeamId, int MarkSpellId, short MarkSpellLevel, short MarkId, sbyte MarkType, short MarkimpactCell, List<GameActionMarkedCell> Cells, bool Active ){
            this.MarkAuthorId = MarkAuthorId;
            this.MarkTeamId = MarkTeamId;
            this.MarkSpellId = MarkSpellId;
            this.MarkSpellLevel = MarkSpellLevel;
            this.MarkId = MarkId;
            this.MarkType = MarkType;
            this.MarkimpactCell = MarkimpactCell;
            this.Cells = Cells;
            this.Active = Active;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MarkAuthorId);
            writer.WriteSByte(MarkTeamId);
            writer.WriteInt(MarkSpellId);
            writer.WriteShort(MarkSpellLevel);
            writer.WriteShort(MarkId);
            writer.WriteSByte(MarkType);
            writer.WriteShort(MarkimpactCell);
			writer.WriteShort((short)Cells.Count);
			foreach (var x in Cells)
			{
				x.Serialize(writer);
			}
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            MarkAuthorId = reader.ReadDouble();
            MarkTeamId = reader.ReadSByte();
            MarkSpellId = reader.ReadInt();
            MarkSpellLevel = reader.ReadShort();
            MarkId = reader.ReadShort();
            MarkType = reader.ReadSByte();
            MarkimpactCell = reader.ReadShort();
            var CellsCount = reader.ReadShort();
            Cells = new List<GameActionMarkedCell>();
            for (var i = 0; i < CellsCount; i++)
            {
                var objectToAdd = new GameActionMarkedCell();
                objectToAdd.Deserialize(reader);
                Cells.Add(objectToAdd);
            }
            Active = reader.ReadBoolean();
        }
    }
}
