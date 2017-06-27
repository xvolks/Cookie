using System;

namespace Cookie.API.Messages
{
    [Flags]
    public enum MessageValidityCheckRoutines
    {
        None = 0,
        BotNotNull = 1,
        CharacterNotNull = 3,
        CharacterFighting = 7
    }
}