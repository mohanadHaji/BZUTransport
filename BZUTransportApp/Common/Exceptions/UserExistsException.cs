namespace BZUCommon.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException() : base("User Already exists")
        {
        }

        public UserExistsException(string message) : base(message)
        {
        }
    }
}
