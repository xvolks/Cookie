

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("WorldMaps")]
    public class WorldMap : IDataObject
    {
        public const String MODULE = "WorldMaps";
        public int Id;
        public uint NameId;
        public int OrigineX;
        public int OrigineY;
        public float MapWidth;
        public float MapHeight;
        public uint HorizontalChunck;
        public uint VerticalChunck;
        public Boolean ViewableEverywhere;
        public float MinScale;
        public float MaxScale;
        public float StartScale;
        public int CenterX;
        public int CenterY;
        public int TotalWidth;
        public int TotalHeight;
        public List<String> Zoom;
    }
}