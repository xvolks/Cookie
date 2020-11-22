using System;

namespace Cookie.API.Utils.Extensions
{
    public class SimplerTimer : IDisposable
    {
        private Action m_action;
        private int m_intervalMillis;

        public SimplerTimer()
        {
        }

        /// <summary>
        ///     Creates a new timer with the given start delay, interval, and callback.
        /// </summary>
        /// <param name="delay">the delay before firing initially</param>
        /// <param name="intervalMillis">the interval between firing</param>
        /// <param name="callback">the callback to fire</param>
        public SimplerTimer(int delay, int intervalMillis, Action callback)
        {
            MillisSinceLastTick = -1;
            m_action = callback;
            RemainingTime = delay;
            m_intervalMillis = intervalMillis;
        }

        public SimplerTimer(Action callback)
            : this(0, 0, callback)
        {
        }

        /// <summary>
        ///     The amount of time in milliseconds that elapsed between the last timer tick and the last update.
        /// </summary>
        public int MillisSinceLastTick { get; private set; }

        public int RemainingTime { get; private set; }

        /// <summary>
        ///     Whether or not the timer is running.
        /// </summary>
        public bool IsRunning => MillisSinceLastTick >= 0;

        /// <summary>
        ///     Stops and cleans up the timer.
        /// </summary>
        public void Dispose()
        {
            Stop();
            m_action = null;
        }

        /// <summary>
        ///     Starts the timer.
        /// </summary>
        public void Start()
        {
            MillisSinceLastTick = 0;
        }

        /// <summary>
        ///     Starts the timer with the given delay.
        /// </summary>
        /// <param name="initialDelay">the delay before firing initially</param>
        public void Start(int initialDelay)
        {
            RemainingTime = initialDelay;
            MillisSinceLastTick = 0;
        }

        /// <summary>
        ///     Starts the time with the given delay and interval.
        /// </summary>
        /// <param name="initialDelay">the delay before firing initially</param>
        /// <param name="interval">the interval between firing</param>
        public void Start(int initialDelay, int interval)
        {
            RemainingTime = initialDelay;
            m_intervalMillis = interval;
            MillisSinceLastTick = 0;
        }

        /// <summary>
        ///     Stops the timer.
        /// </summary>
        public void Stop()
        {
            MillisSinceLastTick = -1;
        }

        /// <summary>
        ///     Updates the timer, firing the callback if enough time has elapsed.
        /// </summary>
        /// <param name="dtMillis">the time change since the last update</param>
        public void Update(int dtMillis)
        {
            // means this timer is not running.
            if (MillisSinceLastTick == -1)
                return;

            if (RemainingTime > 0)
            {
                RemainingTime -= dtMillis;

                if (RemainingTime <= 0)
                    if (m_intervalMillis == 0)
                    {
                        // we need to stop the timer if it's only
                        // supposed to fire once.
                        Stop();
                        m_action();
                    }
                    else
                    {
                        m_action();
                        MillisSinceLastTick = 0;
                    }
            }
            else
            {
                // update our idle time
                MillisSinceLastTick += dtMillis;

                if (MillisSinceLastTick >= m_intervalMillis)
                {
                    // time to tick
                    m_action();
                    if (MillisSinceLastTick != -1)
                        MillisSinceLastTick -= m_intervalMillis;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(SimplerTimer)) return false;
            return Equals((SimplerTimer) obj);
        }

        public bool Equals(SimplerTimer obj)
        {
            // needs to be improved
            return obj.m_intervalMillis == m_intervalMillis && Equals(obj.m_action, m_action);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (m_intervalMillis * 397) ^ (m_action != null ? m_action.GetHashCode() : 0);
                return result;
            }
        }
    }
}