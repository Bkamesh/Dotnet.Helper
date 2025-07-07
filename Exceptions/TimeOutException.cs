namespace dotnet.helper.Exceptions
{
    public class TimeoutException : Exception
    {
        public TimeoutException(string message) : base(message)
        {
        }
    }
}
