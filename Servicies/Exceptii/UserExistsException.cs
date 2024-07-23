namespace ServerApi.Servicies.Exceptii
{
    public class UserExistsException : Exception
    {
        public UserExistsException(string message) : base(message)
        {
        }
    }
}
