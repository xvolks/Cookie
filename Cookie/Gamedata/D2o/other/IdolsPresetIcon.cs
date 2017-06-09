using Cookie.Gamedata.D2o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.GameData.D2O
{
    [D2oClass("IdolsPresetIcons")]
    public class IdolsPresetIcon : IDataObject
    {
        public int id;
        public int order;
    }
}
