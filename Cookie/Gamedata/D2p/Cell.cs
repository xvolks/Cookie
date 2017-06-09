using Cookie.Gamedata.D2p.Elements;
using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cookie.Gamedata.D2p
{
    public class Cell
    {
        // Methods
        internal void Init(IDataReader Reader, int MapVersion)
        {
            CellId = Reader.ReadShort();
            ElementsCount = Reader.ReadShort();
            for (int i = 0; i < ElementsCount; i++)
            {
                BasicElement be = BasicElement.GetElementFromType(Reader.ReadByte());
                be.Init(Reader, MapVersion);
                Elements.Add(be);
            }
        }

        // Fields
        public int CellId;
        public List<BasicElement> Elements = new List<BasicElement>();
        public int ElementsCount;
    }
}
