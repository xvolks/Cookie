using Cookie.Core;
using Cookie.Protocol.Network.Messages.Security;
using System;
using System.Collections.Generic;

namespace Cookie.Handlers.Security
{
    public class SecurityHandlers
    {

        [MessageHandler(RawDataMessage.ProtocolId)]
        private void RawDataMessageHandler(DofusClient client, RawDataMessage message)
        {
            List<int> tt = new List<int>();
            for (int i = 0; i <= 255; i++)
            {
                Random random = new Random();
                int test = random.Next(-127, 127);
            }
            CheckIntegrityMessage rawData = new CheckIntegrityMessage(tt);
            client.Send(rawData);
        }
    }
}
