using System;
using System.Windows.Forms;

namespace Cookie.Utils.Extensions
{
    public static class ActionExtensions
    {
        public static void RunAfter(this Action action, int ms)
        {
            var dispatcherTimer = new Timer {Interval = ms};
            dispatcherTimer.Tick += (sender, args) =>
            {
                var timer = sender as Timer;
                timer?.Stop();

                action();
            };
            dispatcherTimer.Start();
        }
    }
}
