using System;
using Cookie.Commands.Interfaces;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class FooCommand : ICommand
    {
        public string CommandName => "foo";

        public void OnCommand(DofusClient client, string[] args)
        {
            foreach (var s in args)
                client.Logger.Log(s);
        }
    }
}
