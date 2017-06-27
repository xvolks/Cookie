// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Protocol.Datacenter
{
    [D2oClass("Servers")]
    public class Server : IDataObject
    {
        public const string MODULE = "Servers";
        public uint CommentId;
        public int CommunityId;
        public uint GameTypeId;
        public int Id;
        public string Language;
        public uint NameId;
        public float OpeningDate;
        public int PopulationId;
        public List<string> RestrictedToLanguages;
    }
}