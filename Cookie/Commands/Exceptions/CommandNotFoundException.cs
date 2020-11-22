using System;

namespace Cookie.Commands.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException() : base("Command not found !")
        {
        }
    }
}