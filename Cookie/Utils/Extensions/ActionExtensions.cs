using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie.Utils.Extensions
{
    public static class ActionExtensions
    {
        public static void RunAfter(this Action action, int ms) =>
            Task.Factory.StartNew(() => System.Threading.Thread.Sleep(ms)).ContinueWith(t => action());
    }
}
