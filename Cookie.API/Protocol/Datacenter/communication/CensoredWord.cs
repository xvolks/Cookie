// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("CensoredWords")]
    public class CensoredWord : IDataObject
    {
        public const string MODULE = "CensoredWords";
        public bool DeepLooking;
        public uint Id;
        public string Language;
        public uint ListId;
        public string Word;
    }
}