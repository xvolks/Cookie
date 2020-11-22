using Cookie.API.Core;

namespace Cookie.API.Commands
{
    public interface ICommand
    {
        /// <summary>
        ///     The name of your function to be called after with .CommandName
        /// </summary>
        string CommandName { get; }

        /// <summary>
        ///     The name of arguments wich should be used with .CommandName
        /// </summary>
        string ArgsName { get; }

        /// <summary>
        ///     This function will be called when we trigger this command
        /// </summary>
        /// <param name="client"></param>
        /// <param name="args"></param>
        void OnCommand(IAccount client, string[] args);
    }
}