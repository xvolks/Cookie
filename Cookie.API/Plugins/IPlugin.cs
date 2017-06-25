using Cookie.API.Core;

namespace Cookie.API.Plugins
{
    public interface IPlugin
    {
        IDofusClient Client { get; set; }
        void OnLoad(IDofusClient client);
    }
}