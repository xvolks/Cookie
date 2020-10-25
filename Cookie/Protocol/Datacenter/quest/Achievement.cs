

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Achievements")]
    public class Achievement : IDataObject
    {
        public const String MODULE = "Achievements";
        public uint Id;
        public uint NameId;
        public uint CategoryId;
        public uint DescriptionId;
        public int IconId;
        public uint Points;
        public uint Level;
        public uint Order;
        public Boolean AccountLinked;
        public float KamasRatio;
        public float ExperienceRatio;
        public Boolean KamasScaleWithPlayerLevel;
        public List<int> ObjectiveIds;
        public List<int> RewardIds;
    }
}