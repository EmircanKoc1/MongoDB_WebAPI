using System.Reflection;

namespace Core.Exceptions
{
    public class DefaultException : Exception
    {
        public DefaultException(string message = "MessageNotAdded") : base(message)
        {

        }
    }
}
