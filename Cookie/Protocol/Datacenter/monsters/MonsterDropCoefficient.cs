

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MonsterDropCoefficients")]
    public class MonsterDropCoefficient : IDataObject
    {
        public const String MODULE = "MonsterDropCoefficients";
        public int Id;
        public int MonsterId;
        public int MonsterGrade;
        public double DropCoefficient;
        public String Criteria;
    }
}