using Core.Enums;
using Core.Exceptions;

namespace Core.Helper
{
    public static class ExceptionHelper
    {
        public static void ThrowException(ExceptionTypes exceptionType = ExceptionTypes.DefaultException)
        {

            throw exceptionType switch
            {
                ExceptionTypes.EntityAlreadyExistsException => new EntityAlreadyExistsException(),
                ExceptionTypes.EntityNotFoundException => new EntityNotFoundException(),
                ExceptionTypes.DefaultException => new DefaultException("DefaultException"),
                _ => new DefaultException("DefaultException")
            };

        }

    }
}
