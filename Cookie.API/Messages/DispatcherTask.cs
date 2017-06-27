using System.Threading.Tasks;

namespace Cookie.API.Messages
{
    public class DispatcherTask
    {
        public DispatcherTask(MessageDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            Processor = this;
        }

        public DispatcherTask(MessageDispatcher dispatcher, object processor)
        {
            Dispatcher = dispatcher;
            Processor = processor;
        }

        public MessageDispatcher Dispatcher { get; }

        public bool Running { get; private set; }

        public object Processor { get; set; }

        public void Start()
        {
            Running = true;
            Task.Factory.StartNew(Process);
        }

        public void Stop()
        {
            Running = false;
        }

        private void Process()
        {
            while (Running)
            {
                Dispatcher.Wait();

                if (Running)
                    Dispatcher.ProcessDispatching(Processor);
            }
        }
    }
}