using System;
using System.Threading;

namespace Cookie.API.Utils
{
    public class TimerCore : IDisposable
    {
        #region Properties

        private readonly Timer _tm;
        private readonly AutoResetEvent _autoEvent;
        private readonly Action _callback;
        private int _delay;

        #endregion

        #region Constructor

        public TimerCore(Action callback, int global)
        {
            _callback = callback;
            _autoEvent = new AutoResetEvent(false);
            _tm = new Timer(Execute, _autoEvent, global, 0);
        }

        public TimerCore(Action callback, int global, int delay)
        {
            _callback = callback;
            _autoEvent = new AutoResetEvent(false);
            _delay = delay;
            _tm = new Timer(ExecutePeriod, _autoEvent, global, delay);
        }

        #endregion

        #region Methods

        private void Execute(object stateInfo)
        {
            _callback?.Invoke();
            Dispose();
        }

        private void ExecutePeriod(object stateInfo)
        {
            _callback?.Invoke();
        }

        public void Dispose()
        {
            _tm.Dispose();
            _autoEvent.Dispose();
        }

        #endregion
    }
}