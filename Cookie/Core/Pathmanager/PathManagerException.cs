using System;
using System.Runtime.Serialization;

namespace Cookie.Core.Pathmanager
{
    [Serializable]
    public sealed class PathManagerException : Exception
    {
        public PathManagerException()
        {
        }

        public PathManagerException(string message) : base(message)
        {
        }

        public PathManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}