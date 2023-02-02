namespace SchemaTranslators.APIResponseModels
{
    public class Error
    {
        public Error(string message, string? stack, string exception, string? innerException)
        {
            Message=message;
            Stack=stack;
            Exception=exception;
            InnerException=innerException;
        }

        public string Message { get; }
        public string? Stack { get; }
        public string Exception { get; }
        public string? InnerException { get; }
    }
}
