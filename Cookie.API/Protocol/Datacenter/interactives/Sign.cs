using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Protocol.Datacenter.interactives
{
    [D2oClass("Signs")]
    public class Sign : IDataObject
    {
        public const string MODULE = "Signs";
        public int Id;
        public string Params;
        public int SkillId;
        public uint TextKey;
    }
}
