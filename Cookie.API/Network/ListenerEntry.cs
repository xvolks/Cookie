using System;

namespace Cookie.API.Network
{
    [Flags]
    public enum ListenerEntry
    {
        Undefined = 0,
        Local = 1,
        Client = 2,
        Server = 4
    }
}