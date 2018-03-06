using System;

using Frings.SePin.Data;

namespace Frings.SePin.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult error)
        {
            Error = error;
        }

        public ValidationResult Error { get; }
    }
}
