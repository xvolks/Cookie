﻿// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ServerTemporisSeasons")]
    public class ServerTemporisSeason : IDataObject
    {
        public const String MODULE = "ServerTemporisSeasons";
        public int Uid;
        public int SeasonNumber;
        public String Information;
        public double Beginning;
        public double Closure;
    }
}
