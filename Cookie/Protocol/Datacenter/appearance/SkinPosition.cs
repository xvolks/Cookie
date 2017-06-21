// Generated on 12/06/2016 11:35:49

using System.Collections.Generic;
using Cookie.Gamedata.D2o;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("SkinPositions")]
    public class SkinPosition : IDataObject
    {
        private const string MODULE = "SkinPositions";
        public List<string> Clip;
        public uint Id;
        public List<uint> Skin;
        public List<TransformData> Transformation;
    }
}