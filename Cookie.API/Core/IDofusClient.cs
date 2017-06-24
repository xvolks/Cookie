using System;
using Cookie.Core;

namespace Cookie.API.Core
{
    public interface IDofusClient
    {
        void Register(Type type);
        void Log(string text, LogMessageType type = LogMessageType.Default);
    }
}
