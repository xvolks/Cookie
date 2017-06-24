// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("WorldMaps")]
    public class WorldMap : IDataObject
    {
        public const string MODULE = "WorldMaps";
        public int CenterX;
        public int CenterY;
        public uint HorizontalChunck;
        public int Id;
        public float MapHeight;
        public float MapWidth;
        public float MaxScale;
        public float MinScale;
        public uint NameId;
        public int OrigineX;
        public int OrigineY;
        public float StartScale;
        public int TotalHeight;
        public int TotalWidth;
        public uint VerticalChunck;
        public bool ViewableEverywhere;
        public List<string> Zoom;
    }
}