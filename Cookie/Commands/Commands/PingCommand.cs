using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using System;
using System.Diagnostics;

namespace Cookie.Commands.Commands
{
    public class PingCommand : ICommand
    {
        public string CommandName => "ping";
        public string ArgsName => "void";
        Stopwatch Stopwatch { get; set; }
        public void OnCommand(IAccount account, string[] args)
        {
           
            ((Core.Frames.BasicFrame)account.BasicFrame).PongMessageEvent += PongReceived;
            account.Network.SendToServer(new BasicPingMessage(false));
            Stopwatch = Stopwatch.StartNew();
        }

        private void PongReceived(IAccount account, BasicPongMessage e)
        {
            Logger.Default.Log($"Pong {Stopwatch.ElapsedMilliseconds}ms !");
            ((Core.Frames.BasicFrame)account.BasicFrame).PongMessageEvent -= PongReceived;
            Stopwatch.Stop();
        }
    }
}