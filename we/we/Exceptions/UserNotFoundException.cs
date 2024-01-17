namespace we.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException():base("User is not exsisit or parametrs are false") { }
        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
