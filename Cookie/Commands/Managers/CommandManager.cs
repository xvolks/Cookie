using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.Commands.Exceptions;

namespace Cookie.Commands.Managers
{
    public class CommandManager
    {
        static CommandManager()
        {
            var commands =
                from type in Assembly.GetEntryAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                select type;

            var cases = new List<SwitchCase>(commands.Count());

            // Parameters from Action<T1, T2>
            var commandName = Expression.Parameter(typeof(string), "commandName");
            var args = Expression.Parameter(typeof(string[]), "args");
            var client = Expression.Parameter(typeof(IAccount), "account");

            cases.AddRange(from com in commands
                let cmdName = (Activator.CreateInstance(com) as ICommand).CommandName
                let onCommandMethod = com.GetMethod("OnCommand")
                let callOnCommandMethod = Expression.Call(Expression.New(com.GetConstructor(Type.EmptyTypes)),
                    onCommandMethod, client, args)
                let block = Expression.Block(callOnCommandMethod)
                select Expression.SwitchCase(block, Expression.Constant(cmdName)));

            var throwEx = Expression.Throw(Expression.New(typeof(CommandNotFoundException)));

            var defaultBody = Expression.Block(throwEx);

            var se = Expression.Switch(commandName, defaultBody, cases.ToArray());
            Parser = Expression.Lambda<Action<IAccount, string, string[]>>(se, client, commandName, args).Compile();
        }

        private static Action<IAccount, string, string[]> Parser { get; }

        public static void ParseAndCall(IAccount client, string str)
        {
            if (str == string.Empty)
                throw new NoCommandException();

            var toParse = str.Split(' ');

            var command = toParse.First().ToLower();
            var args = toParse.Where(x => x != command).ToArray();

            Parser(client, command, args);
        }

        public static void Build()
        {
        }
    }
}