using System.Collections.Generic;
using Cookie.API.Gamedata.D2p.Elements;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public class Cell
    {
        // Fields
        public int CellId;

        public List<BasicElement> Elements = new List<BasicElement>();

        public int ElementsCount;

        // Methods
        internal void Init(IDataReader Reader, int MapVersion)
        {
            CellId = Reader.ReadShort();
            ElementsCount = Reader.ReadShort();
            for (var i = 0; i < ElementsCount; i++)
            {
                var be = BasicElement.GetElementFromType(Reader.ReadByte());
                be.Init(Reader, MapVersion);
                Elements.Add(be);
            }
        }
    }
}