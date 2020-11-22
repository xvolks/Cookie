using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameActionMark : NetworkType
    {
        public const short ProtocolId = 351;
        public override short TypeId { get { return ProtocolId; } }

        public double MarkAuthorId = 0;
        public byte MarkTeamId = 2;
        public int MarkSpellId = 0;
        public short MarkSpellLevel = 0;
        public short MarkId = 0;
        public byte MarkType = 0;
        public short MarkimpactCell = 0;
        public List<GameActionMarkedCell> Cells;
        public bool Active = false;

        public GameActionMark()
        {
        }

        public GameActionMark(
            double markAuthorId,
            byte markTeamId,
            int markSpellId,
            short markSpellLevel,
            short markId,
            byte markType,
            short markimpactCell,
            List<GameActionMarkedCell> cells,
            bool active
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MarkAuthorId);
            writer.WriteByte(MarkTeamId);
            writer.WriteInt(MarkSpellId);
            writer.WriteShort(MarkSpellLevel);
            writer.WriteShort(MarkId);
            writer.WriteByte(MarkType);
            writer.WriteShort(MarkimpactCell);
            writer.WriteShort((short)Cells.Count());
            foreach (var current in Cells)
            {
                current.Serialize(writer);
            }
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MarkAuthorId = reader.ReadDouble();
            MarkTeamId = reader.ReadByte();
            MarkSpellId = reader.ReadInt();
            MarkSpellLevel = reader.ReadShort();
            MarkId = reader.ReadShort();
            MarkType = reader.ReadByte();
            MarkimpactCell = reader.ReadShort();
            var countCells = reader.ReadShort();
            Cells = new List<GameActionMarkedCell>();
            for (short i = 0; i < countCells; i++)
            {
                GameActionMarkedCell type = new GameActionMarkedCell();
                type.Deserialize(reader);
                Cells.Add(type);
            }
            Active = reader.ReadBoolean();
        }
    }
}