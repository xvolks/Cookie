using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using System.Reflection;
using System.Linq;
using System;

namespace Cookie.Commands.Commands
{
    public class HelpCommand : ICommand
    {
        public string CommandName => "help";
        public string ArgsName => "void";

        public void OnCommand(IAccount account, string[] args)
        {
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                           where type.Namespace == "Cookie.Commands.Commands"
                           select (type);
            foreach (Type cmd in commands)
            {
                try
                {
                    ICommand cmdInstance = Activator.CreateInstance(cmd) as ICommand;
                    string cmdName = cmdInstance.CommandName;
                    string cmdArgs = cmdInstance.ArgsName;
                    Logger.Default.Log($".{cmdName}({cmdArgs})", LogMessageType.Help);
                }
                catch (Exception) { }
            }
        }
    }
}