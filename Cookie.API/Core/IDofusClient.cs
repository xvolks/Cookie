using System;

namespace Cookie.API.Core
{
    public interface IDofusClient
    {
        void Register(Type type);
        void Log(string text);
    }
}
