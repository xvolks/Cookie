using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie.API.Utils.Extensions
{
    public class SelfRunningTaskQueue : INotifyPropertyChanged
    {
        private readonly LockFreeQueue<Action> m_messageQueue;
        private readonly Stopwatch m_queueTimer;
        private readonly List<SimplerTimer> m_timers;
        private int m_currentThreadId;
        private int m_lastUpdate;

        private Task m_updateTask;

        protected SelfRunningTaskQueue(int updateInterval)
        {
            m_timers = new List<SimplerTimer>();
            m_messageQueue = new LockFreeQueue<Action>();
            m_queueTimer = Stopwatch.StartNew();
            UpdateInterval = updateInterval;
        }

        public virtual string Name { get; set; }

        public int UpdateInterval { get; set; }

        public bool Running { get; protected set; }

        public bool IsInContext => Thread.CurrentThread.ManagedThreadId == m_currentThreadId;

        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void Start()
        {
            Running = true;

            m_updateTask = Task.Factory.StartNewDelayed(UpdateInterval, Tick);
        }

        public virtual void Stop()
        {
            Running = false;
        }

        public void AddMessage(Action action)
        {
            m_messageQueue.Enqueue(action);
        }

        public void EnsureNotContext()
        {
            if (IsInContext)
                throw new InvalidOperationException("Forbidden context");
        }

        public void EnsureContext()
        {
            if (!IsInContext)
                throw new InvalidOperationException("Not in context");
        }

        public bool ExecuteInContext(Action action)
        {
            if (IsInContext)
            {
                action();
                return true;
            }

            AddMessage(action);
            return false;
        }

        public void AddTimer(SimplerTimer timer)
        {
            AddMessage(() => m_timers.Add(timer));
        }

        public void RemoveTimer(SimplerTimer timer)
        {
            AddMessage(() => m_timers.Remove(timer));
        }

        public SimplerTimer CallPeriodically(int delayMillis, Action callback)
        {
            var timer = new SimplerTimer(0, delayMillis, callback);
            timer.Start();
            AddTimer(timer);
            return timer;
        }

        public SimplerTimer CallDelayed(int delayMillis, Action callback)
        {
            var timer = new SimplerTimer(delayMillis, 0, callback);
            timer.Start();
            AddTimer(timer);
            return timer;
        }

        public void CancelAllMessages()
        {
            m_messageQueue.Clear();
        }

        protected virtual void OnTick()
        {
        }

        private void Tick()
        {
            if (!Running)
                return;

            try
            {
                if (Interlocked.CompareExchange(ref m_currentThreadId, Thread.CurrentThread.ManagedThreadId, 0) == 0)
                {
                    var timerStart = m_queueTimer.ElapsedMilliseconds;
                    var updateDt = (int) (timerStart - m_lastUpdate);
                    m_lastUpdate = (int) timerStart;

                    // do stuff here

                    // process timer entries
                    foreach (var timer in m_timers)
                    {
                        if (!timer.IsRunning)
                        {
                            RemoveTimer(timer);
                            continue;
                        }

                        try
                        {
                            timer.Update(updateDt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        if (!timer.IsRunning)
                            RemoveTimer(timer);

                        if (!Running)
                        {
                            Interlocked.Exchange(ref m_currentThreadId, 0);
                            return;
                        }
                    }

                    Action msg;
                    while (m_messageQueue.TryDequeue(out msg))
                    {
                        try
                        {
                            msg();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        if (!Running)
                        {
                            Interlocked.Exchange(ref m_currentThreadId, 0);
                            return;
                        }
                    }

                    OnTick();

                    Interlocked.Exchange(ref m_currentThreadId, 0);

                    // get the end time
                    var timerStop = m_queueTimer.ElapsedMilliseconds;

                    var updateLagged = timerStop - timerStart > UpdateInterval;
                    var callbackTimeout = updateLagged ? 0 : timerStart + UpdateInterval - timerStop;

                    Interlocked.Exchange(ref m_currentThreadId, 0);

                    if (Running)
                        m_updateTask = Task.Factory.StartNewDelayed((int) callbackTimeout, Tick);
                }
                else
                {
                    Debug.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}