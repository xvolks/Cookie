using System;

namespace Cookie.Core
{
    [Serializable]
    public sealed class BotNotRunningException : Exception
    {
        public BotNotRunningException () : base("No bot instance is running") { }
        public BotNotRunningException (string message) : base(message) { }
        public  BotNotRunningException (string message, Exception innerException) : base(message, innerException) { }
    }
}
