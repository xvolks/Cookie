// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundBones")]
    public class SoundBones : IDataObject
    {
        public uint Id;
        public List<string> Keys;
        public string MODULE = "SoundBones";
        public List<List<SoundAnimation>> Values;
    }
}