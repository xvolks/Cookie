

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Servers")]
    public class Server : IDataObject
    {
        public const String MODULE = "Servers";
        public int Id;
        public uint NameId;
        public uint CommentId;
        public float OpeningDate;
        public String Language;
        public int PopulationId;
        public uint GameTypeId;
        public int CommunityId;
        public List<String> RestrictedToLanguages;
    }
}