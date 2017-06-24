// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Achievements")]
    public class Achievement : IDataObject
    {
        public const string MODULE = "Achievements";
        public uint CategoryId;
        public uint DescriptionId;
        public float ExperienceRatio;
        public int IconId;
        public uint Id;
        public float KamasRatio;
        public bool KamasScaleWithPlayerLevel;
        public uint Level;
        public uint NameId;
        public List<int> ObjectiveIds;
        public uint Order;
        public uint Points;
        public List<int> RewardIds;
    }
}