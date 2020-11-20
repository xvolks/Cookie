using Cookie.API.Core;
using Cookie.API.Game.Inventory;
using Cookie.API.Protocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie.Game.Inventory
{
    public class Idols : IIdols
    {
        public IAccount Account { get; }
        public AutoResetEvent IdolsResetEvent { get; }
        public Idols(IAccount account)
        {
            Account = account;
            IdolsResetEvent = new AutoResetEvent(false);

            Account.Network.RegisterPacket<IdolSelectedMessage>(HandleIdolSelectedMessage, API.Messages.MessagePriority.VeryHigh);
        }
        #region Handlers
        private void HandleIdolSelectedMessage(IAccount account, IdolSelectedMessage message)
        {
            IdolsResetEvent.Set();
        }
        #endregion
    }
}
