

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SoundUi")]
    public class SoundUi : IDataObject
    {
        public String MODULE = "SoundUi";
        public uint Id;
        public String UiName;
        public String OpenFile;
        public String CloseFile;
        public List<SoundUiElement> SubElements;
    }
}