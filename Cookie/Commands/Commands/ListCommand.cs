using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using System.Reflection;
using System.Linq;
using System;

namespace Cookie.Commands.Commands
{
    public class ListCommand : ICommand
    {
        public string CommandName => "list";
        public string ArgsName => "void";

        public void OnCommand(IAccount account, string[] args)
        {
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                           where type.Namespace == "Cookie.Commands.Commands"
                           select (type);
            foreach (Type cmd in commands)
            {
                ICommand cmdInstance = Activator.CreateInstance(cmd) as ICommand;
                string cmdName = cmdInstance.CommandName;
                string cmdArgs = cmdInstance.ArgsNames;
                Logger.Default.Log($"{cmdName}({cmdArgs})");
            }
        }
    }
}