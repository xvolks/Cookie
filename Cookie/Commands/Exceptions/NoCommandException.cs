using System;

namespace Cookie.Commands.Exceptions
{
    public class NoCommandException : Exception
    {
        public NoCommandException() : base("Please, write a command !")
        {
        }
    }
}