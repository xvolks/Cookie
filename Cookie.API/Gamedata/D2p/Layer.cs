using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public class Layer
    {
        // Fields
        public List<Cell> Cells = new List<Cell>();

        public int CellsCount;

        public int LayerId;

        // Methods
        internal void Init(IDataReader Reader, int MapVersion)
        {
            if (MapVersion >= 9)
                LayerId = Reader.ReadSByte();
            else
                LayerId = Reader.ReadInt();

            CellsCount = Reader.ReadShort();
            for (var i = 0; i < CellsCount; i++)
            {
                var item = new Cell();
                item.Init(Reader, MapVersion);
                Cells.Add(item);
            }
        }
    }
}