using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class TestCommand : ICommand
    {
        public string CommandName => "test";

        public void OnCommand(IDofusClient client, string[] args)
        {
            client.Log("test test test test", LogMessageType.Admin);
        }
    }
}
