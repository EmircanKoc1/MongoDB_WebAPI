using Core.Enums;
using Core.Exceptions;

namespace Core.Helper
{
    public static class ExceptionHelper
    {
        public static void ThrowException(ExceptionTypes exceptionType = ExceptionTypes.DefaultException, string message = "Message not defined")
        {

            throw exceptionType switch
            {
                ExceptionTypes.EntityAlreadyExistsException => new EntityAlreadyExistsException(message),
                ExceptionTypes.EntityNotFoundException => new EntityNotFoundException(message),
                ExceptionTypes.DefaultException => new DefaultException(message),
                ExceptionTypes.ModelValidationException => new ModelValidationException(message),
                _ => new DefaultException(message)
            };

        }

    }
}
