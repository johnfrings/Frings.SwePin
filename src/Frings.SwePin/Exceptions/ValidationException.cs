using System;

using Frings.SwePin.Data;

namespace Frings.SwePin.Exceptions
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
