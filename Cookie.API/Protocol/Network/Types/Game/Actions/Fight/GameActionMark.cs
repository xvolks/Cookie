using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class GameActionMark : NetworkType
    {
        public const ushort ProtocolId = 351;

        public GameActionMark(double markAuthorId, byte markTeamId, int markSpellId, short markSpellLevel, short markId,
            sbyte markType, short markimpactCell, List<GameActionMarkedCell> cells, bool active)
        {
            MarkAuthorId = markAuthorId;
            MarkTeamId = markTeamId;
            MarkSpellId = markSpellId;
            MarkSpellLevel = markSpellLevel;
            MarkId = markId;
            MarkType = markType;
            MarkimpactCell = markimpactCell;
            Cells = cells;
            Active = active;
        }

        public GameActionMark()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double MarkAuthorId { get; set; }
        public byte MarkTeamId { get; set; }
        public int MarkSpellId { get; set; }
        public short MarkSpellLevel { get; set; }
        public short MarkId { get; set; }
        public sbyte MarkType { get; set; }
        public short MarkimpactCell { get; set; }
        public List<GameActionMarkedCell> Cells { get; set; }
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MarkAuthorId);
            writer.WriteByte(MarkTeamId);
            writer.WriteInt(MarkSpellId);
            writer.WriteShort(MarkSpellLevel);
            writer.WriteShort(MarkId);
            writer.WriteSByte(MarkType);
            writer.WriteShort(MarkimpactCell);
            writer.WriteShort((short) Cells.Count);
            for (var cellsIndex = 0; cellsIndex < Cells.Count; cellsIndex++)
            {
                var objectToSend = Cells[cellsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            MarkAuthorId = reader.ReadDouble();
            MarkTeamId = reader.ReadByte();
            MarkSpellId = reader.ReadInt();
            MarkSpellLevel = reader.ReadShort();
            MarkId = reader.ReadShort();
            MarkType = reader.ReadSByte();
            MarkimpactCell = reader.ReadShort();
            var cellsCount = reader.ReadUShort();
            Cells = new List<GameActionMarkedCell>();
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
            {
                var objectToAdd = new GameActionMarkedCell();
                objectToAdd.Deserialize(reader);
                Cells.Add(objectToAdd);
            }
            Active = reader.ReadBoolean();
        }
    }
}