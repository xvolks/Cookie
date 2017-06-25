using Cookie.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.API.Plugins
{
    public interface IPlugin
    {
        void OnLoad(IDofusClient client);
        IDofusClient Client { get; set; }
    }
}
