

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;
using Cookie.Datacenter;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("Subhints")]
    public class Subhint : IDataObject
    {
        public const String MODULE = "Subhints";
        public int Hintid;
        public String Hintparentuid;
        public String Hintanchoredelement;
        public int Hintanchor;
        public int Hintpositionx;
        public int Hintpositiony;
        public int Hintwidth;
        public int Hintheight;
        public String Hinthighlightedelement;
        public int Hintorder;
        public int Hinttooltiptext;
        public int Hinttooltippositionenum;
        public int Hinttooltipurl;
        public int Hinttooltipoffsetx;
        public int Hinttooltipoffsety;
        public int Hinttooltipwidth;
        public double Hintcreationdate;
    }
}