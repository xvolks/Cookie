using System;
using System.Threading.Tasks;

namespace Cookie.API.Utils.Extensions
{
    public static class ActionExtensions
    {
        public static void RunAfter(this Action action, int ms)
        {
            Task.Run(async () =>
            {
                await Task.Delay(ms);
                action.Invoke();
            });
        }
    }
}