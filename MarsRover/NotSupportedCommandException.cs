using System;

namespace MarsRover
{
    public class NotSupportedCommandException : Exception
    {
        private readonly string _errorMessage;

        public NotSupportedCommandException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}