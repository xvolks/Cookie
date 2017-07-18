using System;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Protocol;

namespace Cookie.FullSocket
{
    public class NetworkMessageDispatcher : MessageDispatcher
    {
        public IClient Server { get; set; }

        protected override void Dispatch(Message message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message is NetworkMessage nMessage)
                Dispatch(nMessage, token);
            else
                base.Dispatch(message, token);
        }

        protected void Dispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            if (message.Destinations.HasFlag(ListenerEntry.Local))
                try
                {
                    InternalDispatch(message, token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"Cannot dispatch {message}");
                    Console.Write(ex);
                }

            if (Server != null && message.Destinations.HasFlag(ListenerEntry.Server))
                Server.Send(message);

            message.OnDispatched();
            OnMessageDispatched(message);
        }

        private void InternalDispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            var handlers =
                GetHandlers(message.GetType(), token)
                    .ToArray(); // have to transform it into a collection if we want to add/remove handler


            foreach (var handler in handlers)
            {
                handler.Handler((IAccount) token, message);

                if (message.Canceled)
                    break;
            }
        }
    }
}