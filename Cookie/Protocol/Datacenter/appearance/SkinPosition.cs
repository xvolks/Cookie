

// Generated on 12/06/2016 11:35:49
using Cookie.Gamedata.D2o;
using Cookie.GameData.D2O;
using System;
using System.Collections.Generic;

namespace Cookie.Datacenter
{
    [D2oClass("SkinPositions")]
    public class SkinPosition : IDataObject
    {
        private const String MODULE = "SkinPositions";
        public uint Id;
        public List<TransformData> Transformation;
        public List<String> Clip;
        public List<uint> Skin;
    }
}