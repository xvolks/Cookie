using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cookie.Gamedata.D2p
{
    public class Layer
    {
        // Methods
        internal void Init(IDataReader Reader, int MapVersion)
        {
            if (MapVersion >= 9)
                LayerId = Reader.ReadSByte();
            else
                LayerId = Reader.ReadInt();

            CellsCount = Reader.ReadShort();
            for (int i = 0; i < CellsCount; i++)
            {
                Cell item = new Cell();
                item.Init(Reader, MapVersion);
                Cells.Add(item);
            }
        }

        // Fields
        public List<Cell> Cells = new List<Cell>();
        public int CellsCount;
        public int LayerId;
    }
}
