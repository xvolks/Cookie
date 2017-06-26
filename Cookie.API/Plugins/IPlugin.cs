using Cookie.API.Core;

namespace Cookie.API.Plugins
{
    public interface IPlugin
    {
        /// <summary>
        ///     The client to pass to the plugin
        /// </summary>
        IDofusClient Client { get; set; }

        /// <summary>
        ///     This method is used to load the plugin
        /// </summary>
        /// <param name="client"></param>
        void OnLoad(IDofusClient client);
    }
}