using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Cookie.Commands.Exceptions;
using Cookie.Commands.Interfaces;
using Cookie.Core;

namespace Cookie.Commands.Managers
{
    public class CommandManager
    {
        private static Action<DofusClient, string, string[]> Parser { get; }

        public static void ParseAndCall(DofusClient client, string str)
        {
            if (str == string.Empty)
                throw new NoCommandException();

            var toParse = str.Split(' ');

            var command = toParse.First().ToLower();
            var args = toParse.Where(x => x != command).ToArray();

            Parser(client, command, args);
        }

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
            var client = Expression.Parameter(typeof(DofusClient), "client");

            cases.AddRange(from com in commands
                           let cmdName = (Activator.CreateInstance(com) as ICommand).CommandName
                           let onCommandMethod = com.GetMethod("OnCommand")
                           let callOnCommandMethod = Expression.Call(Expression.New(com.GetConstructor(Type.EmptyTypes)), onCommandMethod, client, args)
                           let block = Expression.Block(callOnCommandMethod)
                           select Expression.SwitchCase(block, Expression.Constant(cmdName)));

            var throwEx = Expression.Throw(Expression.New(typeof(CommandNotFoundException)));

            LabelTarget breakTarget = Expression.Label(typeof(void));
            LabelExpression returnLabel = Expression.Label(breakTarget);

            var defaultBody = Expression.Block(throwEx, returnLabel);

            SwitchExpression se = Expression.Switch(commandName, defaultBody, cases.ToArray());
            Parser = Expression.Lambda<Action<DofusClient, string, string[] >> (se, client, commandName, args).Compile();
        }

        public static void Build()
        { }
    }
}
