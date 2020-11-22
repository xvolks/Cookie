using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterGrade")]
    public class MonsterGrade : IDataObject
    {
		private const string MODULE = "MonsterGrade";
		public int Grade;
		public int MonsterId;
		public int Level;
		public int LifePoints;
		public int ActionPoints;
		public int MovementPoints;
		public int Vitality;
		public int PaDodge;
		public int PmDodge;
		public int Wisdom;
		public int EarthResistance;
		public int AirResistance;
		public int FireResistance;
		public int WaterResistance;
		public int NeutralResistance;
		public int GradeXp;
		public int DamageReflect;
		public uint HiddenLevel;
		public int Strength;
		public int Intelligence;
		public int Chance;
		public int Agility;
    }
}
