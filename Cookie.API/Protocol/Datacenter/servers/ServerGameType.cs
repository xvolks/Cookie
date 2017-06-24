// Generated on 12/06/2016 11:35:52

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerGameTypes")]
    public class ServerGameType : IDataObject
    {
        public const string MODULE = "ServerGameTypes";
        public string DescriptionId;
        public int Id;
        public uint NameId;
        public string RulesId;
        public bool SelectableByPlayer;
    }
}