
using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellVariant")]
    public class SpellVariant : IDataObject
    {
        public const string MODULE = "SpellVariant";
        public int Id;
        public int BreedId;
        public List<int> SpellIds;
        public bool MountAutoTripAllowed;

    }
}