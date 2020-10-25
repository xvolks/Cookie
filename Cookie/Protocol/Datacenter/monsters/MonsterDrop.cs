

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MonsterDrop")]
    public class MonsterDrop : IDataObject
    {
        public uint DropId;
        public int MonsterId;
        public int ObjectId;
        public float PercentDropForGrade1;
        public float PercentDropForGrade2;
        public float PercentDropForGrade3;
        public float PercentDropForGrade4;
        public float PercentDropForGrade5;
        public int Count;
        public Boolean HasCriteria;
        public String Criteria;
        public List<double> SpecificDropCoefficient;
    }
}