using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie.API.Extensions
{
    public static class ActionExtensions
    {
        public static void RunAfter(this Action action, int ms)
        {
            Task.Factory.StartNew(() => Thread.Sleep(ms)).ContinueWith(t => action());
        }
    }
}