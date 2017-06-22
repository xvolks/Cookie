using System;
using System.Collections.Generic;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Security;

namespace Cookie.Handlers.Security
{
    public class SecurityHandlers
    {
        [MessageHandler(RawDataMessage.ProtocolId)]
        private void RawDataMessageHandler(DofusClient client, RawDataMessage message)
        {
            var tt = new List<int>();
            for (var i = 0; i <= 255; i++)
            {
                var random = new Random();
                var test = random.Next(-127, 127);
                tt.Add(test);
            }
            var rawData = new CheckIntegrityMessage(tt);
            client.Send(rawData);
        }
    }
}