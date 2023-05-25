namespace Application
{
    /// <summary>
    /// This impliments the IErrorLogger interface
    /// </summary>
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
