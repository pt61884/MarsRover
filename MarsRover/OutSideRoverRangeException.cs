using System;

namespace MarsRover
{
    public class OutSideRoverRangeException : Exception
    {
        private readonly string _errorMessage;

        public OutSideRoverRangeException(string exceptionErrorMessage)
        {
            _errorMessage = exceptionErrorMessage;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}