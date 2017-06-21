using System;

namespace Cookie.Utils.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            handler?.Invoke(sender, args);
        }
    }
}