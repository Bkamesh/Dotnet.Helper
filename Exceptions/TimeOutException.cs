namespace dotnet.helper
{
    public class TimeoutException : Exception
    {
        public TimeoutException(string message) : base(message)
        {
        }
    }
}
