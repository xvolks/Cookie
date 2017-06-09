

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("CensoredWords")]
    public class CensoredWord : IDataObject
    {
        public const String MODULE = "CensoredWords";
        public uint Id;
        public uint ListId;
        public String Language;
        public String Word;
        public Boolean DeepLooking;
    }
}