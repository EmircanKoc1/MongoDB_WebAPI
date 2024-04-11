namespace Core.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message = "MessageNotAdded") : base(message)
        {

        }
    }
}
