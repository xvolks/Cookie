using Cookie.API.Core;

namespace Cookie.API.Plugins
{
    public interface IPlugin
    {
        /// <summary>
        ///     The client to pass to the plugin
        /// </summary>
        IAccount Account { get; set; }

        /// <summary>
        ///     This method is used to load the plugin
        /// </summary>
        void OnLoad();
    }
}