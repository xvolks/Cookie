// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("BreachBosses")]
    public class BreachBoss : IDataObject
    {
        public const String MODULE = "BreachBosses";
        public int Id;
        public uint MonsterId;
        public uint Category;
        public string ApparitionCriterion;
        public string AccessCriterion;
        public uint MaxRewardQuantity;
        public List<int> IncompatibleBosses;
        public int RewardId;
    }
}