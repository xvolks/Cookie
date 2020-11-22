using System;

namespace Cookie.API.Utils.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            handler?.Invoke(sender, args);
        }
    }
}