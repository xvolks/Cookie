using Cookie.Gamedata.D2o;
using System;

namespace Cookie.Datacenter
{
    [D2oClass("ChatChannels")]
    public class ChatChannel : IDataObject
    {
        public const String MODULE = "ChatChannels";
        public uint Id;
        public uint NameId;
        public uint DescriptionId;
        public String Shortcut;
        public String ShortcutKey;
        public Boolean IsPrivate;
        public Boolean AllowObjects;
    }
}