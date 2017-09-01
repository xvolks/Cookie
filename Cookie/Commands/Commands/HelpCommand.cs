using System;
using System.Linq;
using System.Reflection;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

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
                select type;
            foreach (var cmd in commands)
                try
                {
                    var cmdInstance = Activator.CreateInstance(cmd) as ICommand;
                    var cmdName = cmdInstance.CommandName;
                    var cmdArgs = cmdInstance.ArgsName;
                    Logger.Default.Log($".{cmdName}({cmdArgs})", LogMessageType.Help);
                }
                catch (Exception)
                {
                }
        }
    }
}