using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Subhint")]
    public class Subhint : IDataObject
    {
		private const string MODULE = "Subhint";
		public int Hintid;
		public string Hintparentuid;
		public string Hintanchoredelement;
		public int Hintanchor;
		public int Hintpositionx;
		public int Hintpositiony;
		public int Hintwidth;
		public int Hintheight;
		public string Hinthighlightedelement;
		public int Hintorder;
		public int Hinttooltiptext;
		public int Hinttooltippositionenum;
		public string Hinttooltipurl;
		public int Hinttooltipoffsetx;
		public int Hinttooltipoffsety;
		public int Hinttooltipwidth;
		public double Hintcreationdate;
    }
}
